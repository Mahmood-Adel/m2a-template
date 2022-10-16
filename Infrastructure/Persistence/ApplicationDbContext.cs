using System.Globalization;
using System.Reflection;
using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Persistence;

public sealed class ApplicationDbContext :
    IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IApplicationDbContext
{
    private readonly ICurrentUserService _currentUserService;
    private readonly string _userName;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService)
        : base(options)
    {
        _currentUserService = currentUserService;
        if (_currentUserService.UserId != null)
        {
            _userName = Users.FirstOrDefault(x => x.Id == _currentUserService.UserId)?.UserName;
        }
    }

    public DbSet<Test> Tests => Set<Test>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        foreach (var entityType in builder.Model.GetEntityTypes()
                     .Where(x => typeof(CreatableModel).IsAssignableFrom(x.ClrType)))
        {
            
            builder
                .Entity(entityType.ClrType)
                .HasOne(typeof(User))
                .WithMany()
                .HasForeignKey(nameof(CreatableModel.CreatedById))
                .IsRequired(false);
            
            builder
                .Entity(entityType.ClrType)
                .HasOne(typeof(User))
                .WithMany()
                .HasForeignKey(nameof(CreatableModel.DeletedById))
                .IsRequired(false);
        }
    }

    public int ForceSaveChanges()
    {
        return PerformSaveChanges(true);
    }

    public Task<int> ForceSaveChangesAsync()
    {
        return Task.FromResult(PerformSaveChanges(true));
    }

    public override int SaveChanges()
    {
        return PerformSaveChanges(false);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        return Task.FromResult(PerformSaveChanges(false));
    }

    private int PerformSaveChanges(bool force)
    {
        var objectStateEntry = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseModel && e.State != EntityState.Unchanged)
            .ToList();

        foreach (var entry in objectStateEntry)
        {
            if (entry.Entity is not BaseModel entity) continue;

            if ((_currentUserService.UserId == null || string.IsNullOrEmpty(_userName)) && !force)
            {
                entry.State = EntityState.Unchanged;
                continue;
            }

            var creatableEntity = entity as CreatableModel;
            var modifiableEntity = entity as ModifiableModel;

            if (creatableEntity != null)
            {
                creatableEntity.IsDeleted = false;
                creatableEntity.DeletionTime = null;
                creatableEntity.DeletedById = null;
            }

            switch (entry.State)
            {
                case EntityState.Deleted:
                    if (creatableEntity != null)
                    {
                        entry.State = EntityState.Modified;
                        creatableEntity.DeletionTime = DateTime.UtcNow;
                        creatableEntity.IsDeleted = true;
                        creatableEntity.DeletedById = _currentUserService.UserId;
                    }

                    break;

                case EntityState.Modified:
                    if (modifiableEntity != null)
                    {
                        JArray modifications;
                        try
                        {
                            modifications = JArray.Parse(modifiableEntity.ModificationHistory!);
                        }
                        catch (Exception)
                        {
                            modifications = JArray.Parse("[]");
                        }

                        if (modifications.Count == 100)
                            modifications.RemoveAt(0);

                        modifications.Add(JToken.FromObject(new
                        {
                            By = new
                            {
                                Id = _currentUserService.UserId,
                                Name = _userName
                            },
                            Time = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                            Notes = modifiableEntity.ModificationNotes
                        }));

                        modifiableEntity.ModificationHistory = modifications.ToString();
                    }

                    break;

                case EntityState.Added:
                    entity.CreationTime = DateTime.UtcNow;
                    if (creatableEntity != null)
                    {
                        creatableEntity.CreatedById = _currentUserService.UserId;
                    }

                    break;
            }
        }

        return base.SaveChanges();
    }
}