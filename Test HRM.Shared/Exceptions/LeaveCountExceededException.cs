namespace HRM.Shared.Exceptions;

public sealed class LeaveCountExceededException: ApplicationException
{
    public string PropertyName;
    public LeaveCountExceededException(string propertyName, string name, object key)
        : base($"{key} count ({name}) has already exceeded")
    {
        PropertyName = propertyName;
    }
}
