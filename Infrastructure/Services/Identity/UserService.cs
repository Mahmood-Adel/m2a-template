using Application.Common.Interfaces;
using Application.Interfaces.Services.Identity;
using Application.Requests.Identity;
using Application.Wrapper;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Infrastructure.Services.Identity;

public class UserService: IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly ICurrentUserService _currentUserService;
    private readonly IStringLocalizer<UserService> _localizer;

    public UserService(UserManager<User> userManager,ICurrentUserService currentUserService, IStringLocalizer<UserService> localizer)
    {
        _userManager = userManager;
        _currentUserService = currentUserService;
        _localizer = localizer;
    }
    
    public async Task<IResult> RegisterAsync(RegisterRequest request)
    {
        var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);

        if (userWithSameUserName != null)
        {
            return await Result.FailAsync(string.Format(_localizer["username_0_is_already_taken"],
                userWithSameUserName.UserName));
        }

        var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
        if (userWithSameEmail != null)
        {
            return await Result.FailAsync(string.Format(_localizer["email_0_is_already_registered"],
                userWithSameEmail.Email));
        }

        if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
        {
            var userWithSamePhoneNumber =
                await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber);
            if (userWithSamePhoneNumber != null)
            {
                return await Result.FailAsync(string.Format(_localizer["phone_number_0_is_already_registered"],
                    userWithSamePhoneNumber.Email));
            }
        }
        
        var user = new User
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            PhoneNumber = request.PhoneNumber,
            IsActive = request.ActivateUser,
            EmailConfirmed = request.AutoConfirmEmail
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            return await Result.FailAsync(result.Errors.Select(x => x.Description).ToList());
        }
        
        return await Result<Guid>.SuccessAsync(user.Id, string.Format(_localizer["user_0_registered"], user.UserName));
    }
}