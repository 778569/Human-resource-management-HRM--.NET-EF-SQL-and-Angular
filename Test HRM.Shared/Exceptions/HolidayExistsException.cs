namespace HRM.Shared.Exceptions;

public class HolidayExistsException : ApplicationException
{
    public string PropertyName;

    public HolidayExistsException(string propertyName, string message)
        : base(message)
    {
        PropertyName = propertyName;
    }
}
