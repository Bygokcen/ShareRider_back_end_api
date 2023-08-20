using ShareRider2.Models;

namespace ShareRider2.Data;

public interface IAuthRepository
{
    Task<User>Register(User user,string password);
    
    Task<User?> Login (string email,string password);

    Task<bool> UserExists(string email);
}