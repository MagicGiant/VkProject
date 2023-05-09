using BusinessLayer.Exceptions;

namespace BusinessLayer.Entities;

public class Login
{
    private string _login;

    public const int MinSize = 3;

    public Login(string login)
    {
        if (string.IsNullOrEmpty(login))
            throw new ArgumentNullException(nameof(login));

        if (login.Length < MinSize)
            PasswordLoginException.LoginSizeException(login);

        this._login = login;
    }

    public override string ToString()
    {
        return _login;
    }
}