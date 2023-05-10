namespace BusinessLayer.Exceptions;

public class ManagerException: Exception
{
    public ManagerException(String message)
        :base(message)
    {}

    public static ManagerException WrongLoginOrPasswordException()
    {
        return new ManagerException("Wrong password or login");
    }
}