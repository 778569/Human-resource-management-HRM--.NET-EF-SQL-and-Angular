namespace HRM.Shared.Exceptions;

public sealed class RecordAlreadyExistException: ApplicationException
{
	public string PropertyName;
	public RecordAlreadyExistException(string propertyName, string name, object key)
		: base($"{name} ({key}) is already exist")
	{
		PropertyName = propertyName;
	}
}

