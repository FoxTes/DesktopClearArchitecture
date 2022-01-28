namespace DesktopClearArchitecture.Domain.Models
{
    /// <summary>
    /// Song.
    /// </summary>
    public readonly record struct Song
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Duration.
        /// </summary>
        public int Duration { get; init; }
    }
}