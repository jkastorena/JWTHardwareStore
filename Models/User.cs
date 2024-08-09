using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace JWTHardwareStore;

public class User
{
    public User()
    {
        
    }
    public User(string name, string password, string email, string phone)
    {
        var salt = GetSalt();
        Name = name;
        Password = HashPassword(password+salt);
        Email = email;
        Phone = phone;
        Salt = salt;
    }

    [Key]
    public Guid UserId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    public string? Salt { get; set; }
    [Required]
    public string? Phone { get; set; }
    public DateTime CreateOn { get; set; } = DateTime.Now;

    public string GetSalt()
    {

        var Rnd = new byte[16];
        string salt = "";

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(Rnd);
            salt = Convert.ToBase64String(Rnd);
        }
        
        return salt; 
    }



    public string HashPassword(string pass)
    {
        StringBuilder sb = new StringBuilder();
        using (var md5 = SHA256.Create())
        {
            byte[] Md5HashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));

            foreach (byte b in Md5HashBytes)
            {
                sb.Append(b.ToString("X2"));
            }
        }
        return sb.ToString();
    }

}

