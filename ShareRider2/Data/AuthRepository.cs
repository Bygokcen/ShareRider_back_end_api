using Microsoft.EntityFrameworkCore;
using ShareRider2.Models;

namespace ShareRider2.Data;

public class AuthRepository:IAuthRepository
{
    private DataContext _context;

    public AuthRepository(DataContext context)
    {
        _context = context;
    }

    public Task<User> Register(User user, string password)
    {
        CreatePasswordHash(password,out var passwordHash,out var passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

         _context.Users.AddAsync(user);
         Console.WriteLine(user);
         _context.SaveChangesAsync();
        return Task.FromResult(user);
    }

    public async Task<User> Login(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u =>u.Email==email);
        if (user == null)
        {
            return null;
        }

        if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            return null;
        }
        

        return user;
    }

    public async Task<bool> UserExists(string email)
    {
        if (await _context.Users.AnyAsync(u => u.Email.Equals(email)))
        {
            return true;
        }
        return false;
    }

    private void CreatePasswordHash(string password, out byte[] passwordhash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
    
    private bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
    {
        //bu seferr Salt biliniyor ve gönderiyorus ,unutma ki yukarda bis oluşturduk.
        using (var hmac = new System.Security.Cryptography.HMACSHA512(userPasswordSalt))
        {
            var computedHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != userPasswordHash[i])
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}