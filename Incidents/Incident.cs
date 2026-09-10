/// <summary>
/// Represents an emergency incident that needs to be handled by a hero.
/// </summary>
public class Incident
{
    /// <summary>
    /// Gets the description of the incident.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the location of the incident.
    /// </summary>
    public string Location { get; }

    /// <summary>
    /// Gets the severity level of the incident.
    /// </summary>
    public Severity Severity { get; }

    /// <summary>
    /// Gets whether the incident has been resolved.
    /// </summary>
    public bool IsResolved { get; private set; }

    /// <summary>
    /// Creates a new incident.
    /// </summary>
    /// <param name="description">The description of the incident.</param>
    /// <param name="location">The location of the incident.</param>
    /// <param name="severity">The severity level.</param>
    public Incident(string description, string location, Severity severity)
    {
        Description = description;
        Location = location;
        Severity = severity;
        IsResolved = false;
    }

    /// <summary>
    /// Marks the incident as resolved.
    /// </summary>
    public void Resolve()
    {
        IsResolved = true;
    }
}