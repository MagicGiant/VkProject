namespace Database.Exceptions;

public class TransactionsException: Exception
{
    public TransactionsException(string message)
        :base(message)
    {}

    public static TransactionsException AdminCountException()
    {
        return new TransactionsException("Admin can be only one user");
    }
}