namespace LeagueOfLegends.API.Models.DTO;

/// <summary>
/// Class representing a not found request.
/// </summary>
public class NotFoundObject
{
    /// <summary>
    /// Message for the not found request.
    /// </summary>
    public string Message { get; init; }
    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">Message for the not found request.</param>
    public NotFoundObject(string message)
    {
        Message = message;
    }
}