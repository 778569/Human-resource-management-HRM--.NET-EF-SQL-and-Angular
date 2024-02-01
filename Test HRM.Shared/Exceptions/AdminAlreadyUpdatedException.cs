namespace HRM.Shared.Exceptions;

public sealed class AdminAlreadyUpdatedException : ApplicationException
{
    public string PropertyName;
    public AdminAlreadyUpdatedException(string propertyName, string name, object key)
        : base($"{name} Already updated the status as ({key})!")
    {
        PropertyName = propertyName;
    }
}
