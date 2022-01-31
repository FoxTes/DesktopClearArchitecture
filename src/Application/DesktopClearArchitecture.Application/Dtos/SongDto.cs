namespace DesktopClearArchitecture.Application.Dtos;

/// <summary>
/// Song dto.
/// </summary>
public readonly record struct SongDto
{
    /// <summary>
    /// Full name song.
    /// </summary>
    public string FullName { get; init; }

    /// <inheritdoc />
    public override string ToString() => FullName;
}