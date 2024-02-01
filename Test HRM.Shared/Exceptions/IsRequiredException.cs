namespace HRM.Shared.Exceptions;

public class IsRequiredException: ApplicationException
{
    public string PropertyName;

    public IsRequiredException(string propertyName, string name, object key)
        : base($"{name} is required!")
    {
        PropertyName = propertyName;
    }
}
