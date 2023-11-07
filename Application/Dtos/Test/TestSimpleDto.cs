using System.Linq.Expressions;

namespace Application.Dtos.Test;

public class TestSimpleDto
{
    public static Expression<Func<Domain.Entities.Test, TestSimpleDto>> Mapper => item => new TestSimpleDto
    {
        Id = item.Id,
        Name = item.Name,
    };

    public Guid Id { get; set; }
    public string Name { get; set; }
}