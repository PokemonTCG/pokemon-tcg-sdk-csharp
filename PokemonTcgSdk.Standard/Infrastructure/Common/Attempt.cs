namespace PokemonTcgSdk.Standard.Infrastructure.Common;

using System;
using System.Runtime.ExceptionServices;
using Extensions;

public class Attempt<T> : IAttempt
{
    public bool Success { get; }
    public bool Failure => !Success;
    public Error Error { get; }
    public T Result { get; }

    // private - please use static constructors Attempt<T>.Fail() and Attempt<T>.Succeed()
    private Attempt(bool success, T result, Error error)
    {
        this.Success = success;
        this.Result = result;
        this.Error = error;
    }


    /// <summary>Creates a successful attempt with a result.</summary>
    /// <param name="result">The result of the attempt.</param>
    /// <returns>The successful attempt.</returns>
    public static Attempt<T> Succeed(T result)
    {
        return new Attempt<T>(true, result, (Error)null);
    }

    /// <summary>Creates a failed attempt with an exception.</summary>
    /// <param name="error">The error causing the failure of the attempt.</param>
    /// <param name="exitCode">The exit code to use </param>
    /// <returns>The failed attempt.</returns>
    public static Attempt<T> Fail(Error error)
    {
        return new Attempt<T>(false, default(T), error);
    }

    public static Attempt<T> Fail(string errorMessage, Exception exception = null)
    {
        return new Attempt<T>(false, default(T), new Error(errorMessage, exception));
    }

    public static Attempt<T> Fail(Exception exception)
    {
        return new Attempt<T>(false, default(T), new Error(exception.Message, exception));
    }

    public T ThrowOrResult()
    {
        ThrowExceptionIfFailure();
        return Result;
    }

    public void ThrowExceptionIfFailure()
    {
        if (Success)
            return;
        if (Error.Exception != null)
            ExceptionDispatchInfo.Capture(Error.Exception).Throw();
        else
            throw new Exception(Error.Message.DefaultIfEmpty("Unspecified error"));
    }


    public void IfSuccess(Action<T> action)
    {
        if (Success)
            action(Result);
    }

    public void IfFailure(Action<Attempt<T>> action)
    {
        if (Failure)
            action(this);
    }
}

public interface IAttempt
{
    bool Success { get; }
    bool Failure { get; }
    Error Error { get; }
}

public class Error
{
    public Error(string message, Exception exception = null)
    {
        Message = message;
        Exception = exception;
    }

    public string Message { get; set; }
    public Exception Exception { get; set; }
}

public class NotFoundError : Error
{
    public NotFoundError(string message, Exception exception = null) : base(message, exception)
    {
    }


}

public class ForbiddenError : Error
{
    public ForbiddenError(string message, Exception exception = null) : base(message, exception)
    {
    }
}

public class UserFriendlyError : Error
{
    public UserFriendlyError(string userFriendlyMessage, string debugMessage = null, Exception exception = null) : base(debugMessage, exception)
    {
        UserFriendlyMessage = userFriendlyMessage;
    }

    public string UserFriendlyMessage { get; set; }
}