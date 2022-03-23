#nullable enable

namespace DesktopClearArchitecture.Domain.Common.Result;

/// <summary>
/// Represent operation result for SaveChanges.
/// </summary>
public class SaveChangesResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SaveChangesResult"/> class.
    /// </summary>
    public SaveChangesResult() => Messages = new List<string>();

    /// <inheritdoc />
    public SaveChangesResult(string message)
        : this() => AddMessage(message);

    /// <summary>
    /// Is Exception occupied while last operation execution.
    /// </summary>
    public bool IsOk => Exception == null;

    /// <summary>
    /// Last Exception you can find here.
    /// </summary>
    public Exception? Exception { get; set; }

    /// <summary>
    /// List of the error should appear there.
    /// </summary>
    private List<string> Messages { get; }

    /// <summary>
    /// Adds new message to result.
    /// </summary>
    /// <param name="message">Message.</param>
    public void AddMessage(string message) => Messages.Add(message);
}