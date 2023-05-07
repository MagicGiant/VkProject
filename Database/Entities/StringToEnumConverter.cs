using Database.Exceptions;
using Database.Models;

namespace Database.Entities;

public static class StringToEnumConverter<T>
{ 
    
    public static T Execute (String data)
    {
        if (!typeof(T).IsEnum)
            throw EnumToStringConverterException.EnumConverterException();
        
        foreach (var enumObject in Enum.GetValues(typeof(T)).Cast<T>())
        {
            if (enumObject.ToString() == data)
                return enumObject;
        }

        throw EnumToStringConverterException.InvalidStringData(data);
    }
}