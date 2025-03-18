namespace Gravity.Infrastructure.Core.Exceptions;

[Serializable]
public class BusinessException : Exception, IDcsException
{
    public BusinessException(string message)
        : base(message)
    {
        base.HResult = (int)HttpStatusCode.BadRequest;
    }

    public BusinessException(HttpStatusCode statusCode, string message)
    : base(message)
    {
        base.HResult = (int)statusCode;
    }
}