using Business.Requests;
using Business.Responses;

namespace Business.Services
{
    public interface IAuthService
    {
        Task<RegisteredUserResponse> RegisterAsync(RegisterUserRequest request);
        Task<LoggedInUserResponse> LoginAsync(LoginUserRequest request);
    }
}
