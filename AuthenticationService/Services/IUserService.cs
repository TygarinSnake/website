using AuthenticationService.Entitys;
using AuthenticationService.Models;

namespace AuthenticationService.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        Task<AuthenticateResponse> Register(User userModel);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
