namespace ShareRider2.Dtos;

public class UserForLoginDto
{
    public UserForLoginDto(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }
    public string Password { get; set; }
}