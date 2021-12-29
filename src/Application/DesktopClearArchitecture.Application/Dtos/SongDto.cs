namespace DesktopClearArchitecture.Application.Dtos
{
    /// <summary>
    /// Song dto.
    /// </summary>
    public class SongDto
    {
        /// <summary>
        /// Full name song.
        /// </summary>
        public string FullName { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return FullName;
        }
    }
}