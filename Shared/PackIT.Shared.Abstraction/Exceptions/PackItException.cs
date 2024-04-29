namespace PackIT.Shared.Abstraction.Exceptions;

/// <summary>
/// Represent pack it exception class
/// </summary>
/// <param name="message">Exception message or error message</param>
public abstract class PackItException(string message) : Exception(message)
{
}
