namespace DesktopClearArchitecture.Infrastructure.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using DesktopClearArchitecture.Domain.Models;

    /// <summary>
    /// App list.
    /// </summary>
    public class GameList
    {
        /// <summary>
        /// App.
        /// </summary>
        [DataMember(Name = "apps")]
        public List<Game> Games { get; set; }
    }
}