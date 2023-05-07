namespace Database.Exceptions;

public class EnumToStringConverterException: Exception
{
    public EnumToStringConverterException(string message)
        : base(message)
    {}
    
    public static EnumToStringConverterException EnumConverterException()
    {
        return new EnumToStringConverterException("Generic type can be also enum type");
    }

    public static EnumToStringConverterException InvalidStringData(string data)
    {
        return new EnumToStringConverterException($"Can't find field with \"{data}\" string data");
    }
}