using System.Security.Cryptography;
using System.Text;
using BusinessLayer.Exceptions;

namespace BusinessLayer.Entities;

public class Password
{
    private string _password;
    
    public const int MinSize = 4;
    
    public Password(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentNullException(nameof(password));

        if (password.Length < MinSize)
            PasswordLoginException.PasswordSizeException(password);

        this._password = password;
    }

    public string toHashString()
    {
        return GetHash(this._password);
    }
    
    public static string GetHash(string password)
    {
        byte[] hashCode;
        using (SHA256 sha256 = SHA256.Create())
            hashCode = sha256.ComputeHash(Encoding.ASCII.GetBytes(password));
        return Encoding.ASCII.GetString(hashCode);
    }

    public override string ToString()
    {
        return _password;
    }
    
}