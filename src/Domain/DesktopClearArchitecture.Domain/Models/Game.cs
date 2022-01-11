namespace DesktopClearArchitecture.Domain.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Song.
    /// </summary>
    public readonly struct Game
    {
        /// <summary>
        /// Name.
        /// </summary>
        [DataMember(Name = "appid")]
        public int Id { get; init; }

        /// <summary>
        /// Duration.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; init; }
    }
}