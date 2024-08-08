using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace JWTHardwareStore;

public class User
{

    public User(string name, string password, string email, string phone)
    {


        Name = name;
        Password = HashPassword(password);
        Email = email;
        Phone = phone;
    }

    [Key]
    public Guid UserId { get; set; } 
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    public string? Salt { get; set; } = AddSalt();
    [Required]
    public string? Phone { get; set; }
    public DateTime CreateOn { get; set; } = DateTime.Now;


    public static string AddSalt(){

        var r = new Random();
        int A = r.Next(10000, 90000);
        return  A.ToString("X2");
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

