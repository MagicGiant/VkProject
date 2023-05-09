using BusinessLayer.Entities;

namespace BusinessLayer.Exceptions;

public class PasswordLoginException: Exception
{
    public PasswordLoginException(string message)
        : base(message)
    {}

    public static PasswordLoginException LoginSizeException(string login)
    {
        return new PasswordLoginException
            ($"Login size can be also more or equal {Login.MinSize}. Now login is {login}");
    }

    public static PasswordLoginException PasswordSizeException(string password)
    {
        return new PasswordLoginException
            ($"Login size can be also more or equal {Password.MinSize}. Now password size is {password.Length}");
    }
}