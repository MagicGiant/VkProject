namespace BusinessLayer.Exceptions;

public class MenuManagerException: Exception
{
    public MenuManagerException(String message)
        :base(message)
    {}

    public static MenuManagerException WrongLoginOrPasswordException()
    {
        return new MenuManagerException("Wrong password or login");
    }
}