namespace ShareRider2.Dtos;

public class UserForRegisterDto
{
    public UserForRegisterDto(string email, string password, string firstName, string lastName, string gender)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
    }

    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
}