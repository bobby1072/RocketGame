using System.Net;
using Microsoft.Extensions.Logging;

namespace PokeGame.Core.Common.Exceptions;

public sealed class PokeGameApiUserException: PokeGameApiException
{
    public PokeGameApiUserException(HttpStatusCode statusCode, LogLevel overrideLogLevel, string message) : base(statusCode, overrideLogLevel, message) {}
    public PokeGameApiUserException(HttpStatusCode statusCode, string message) : base(statusCode, LogLevel.Information, message) {}
}

