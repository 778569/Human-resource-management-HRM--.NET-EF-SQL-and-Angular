namespace HRM.Shared.Exceptions;

public sealed class FullDayLeaveAlreadyCreatedException : ApplicationException
{
    public string PropertyName;
    public FullDayLeaveAlreadyCreatedException(string propertyName, string name, object key)
        : base($"Full day {name} is already created on {key}")
    { 
        PropertyName = propertyName;
    }
}
