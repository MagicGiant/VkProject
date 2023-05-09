using BusinessLayer.Entities;

namespace BusinessLayer.Exceptions;

public class UserBuilderException : Exception
{
    public UserBuilderException(string message)
        : base(message)
    { }

    public static UserBuilderException CreateUserWithExistLogin(string login)
    {
        return new UserBuilderException($"This login {login} already exist");
    }

    public static UserBuilderException AdminException()
    {
        return new UserBuilderException("Can't be more one Admin");
    }
}