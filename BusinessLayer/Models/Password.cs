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

    public byte[] toHashString()
    {
        return GetHash(this._password);
    }
    
    public static byte[] GetHash(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
            return sha256.ComputeHash(Encoding.ASCII.GetBytes(password));
    }

    public override string ToString()
    {
        return _password;
    }
    
}