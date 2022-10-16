using Application.Requests.Identity;
using Application.Wrapper;

namespace Application.Interfaces.Services.Identity;

public interface IUserService
{
    Task<IResult> RegisterAsync(RegisterRequest request);
}