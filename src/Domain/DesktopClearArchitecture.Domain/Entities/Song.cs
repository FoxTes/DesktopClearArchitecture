namespace DesktopClearArchitecture.Domain.Entities
{
    /// <summary>
    /// Song.
    /// </summary>
    public readonly struct Song
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