namespace HRM.Shared.Exceptions;

public sealed class OperationFailedException : ApplicationException
{
    public string PropertyName;

    public OperationFailedException(string propertyName, string message)
        : base(message)
    {
        PropertyName = propertyName;
    }
}
