using System.Net;
using Microsoft.Extensions.Logging;

namespace PokeGame.Core.Common.Exceptions;

public sealed class PokeGameApiServerException: PokeGameApiException
{
    public PokeGameApiServerException(HttpStatusCode statusCode, LogLevel overrideLogLevel,string message): base(statusCode, overrideLogLevel, message) {}    
    public PokeGameApiServerException(HttpStatusCode statusCode, string message): base(statusCode, LogLevel.Error, message) {}
}