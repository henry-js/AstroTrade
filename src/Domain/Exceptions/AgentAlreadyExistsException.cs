namespace AstroTrade.Domain.Exceptions;

public class AgentAlreadyExistsException : Exception
{
    public AgentAlreadyExistsException(Exception innerException) : base("Agent already exists", innerException)
    {
    }
}
