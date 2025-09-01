namespace ECom.Application.Exceptions;

public class CoreException : Exception
{
    public CoreException(string code, string message)
    {
        Code = code;
        ErrorMessage = message;
    }
    
    public CoreException(string code)
    {
        Code = code;
    }
    
    public string Code { get; set; }
    public string ErrorMessage { get; set; }
}