using System.Net;
using ECom.API.Models;
using ECom.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace ECom.API.Handler;

internal sealed class CoreExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, 
        CancellationToken cancellationToken)
    {
        if (exception is not CoreException coreException)
        {
            return await NativeException(httpContext, exception, cancellationToken);
        }
        
        var jsonResponse = new BaseResponse<string>(null, coreException.ErrorMessage, coreException.Code);
        
        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        await httpContext.Response.WriteAsJsonAsync(jsonResponse, cancellationToken);
        
        return true;
    }

    private async ValueTask<bool> NativeException(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        var jsonResponse = new BaseResponse<string>(null, exception.Message, "InternalServerError");
        
        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        await httpContext.Response.WriteAsJsonAsync(jsonResponse, cancellationToken);
        
        return true;
    }
}