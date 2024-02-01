namespace HRM.Shared.Exceptions;

public sealed class TimeValidationException: ApplicationException
{
	public string PropertyName;

	/// <summary>
	/// Early In Time validation constructor
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="earlyInTime"></param>
	/// <param name="inTime"></param>
	public TimeValidationException(string propertyName, TimeSpan earlyInTime, TimeSpan inTime): base($"Early In Time: {earlyInTime} cannot be later than In Time: {inTime}")
	{
		PropertyName = propertyName;
	}

	/// <summary>
	/// Late Out Time validation constructor
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="lateOutTime"></param>
	/// <param name="earlyInTime"></param>
	/// <param name="outTime"></param>
    public TimeValidationException(string propertyName, TimeSpan lateOutTime, TimeSpan earlyInTime, TimeSpan outTime) : base($"Late Out Time: {lateOutTime} cannot be between Early In Time: {earlyInTime} and Out Time: {outTime}")
    {
        PropertyName = propertyName;
    }


    /// Early Out Time validation constructor
    /// </summary>
    /// <param name="propertyName"></param>
    /// <param name="CuttOffTIme"></param>
    public TimeValidationException(string propertyName, TimeSpan CuttOffTIme) : base($"Out Time cannot be before: {CuttOffTIme}")
    {
        PropertyName = propertyName;
    }
}
