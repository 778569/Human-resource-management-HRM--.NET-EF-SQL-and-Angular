namespace HRM.Shared.Exceptions;

public sealed class UnauthorizedException : ApplicationException
{
    public UnauthorizedException(string message) : base(message)
    {
    }
}
