namespace DesktopClearArchitecture.Domain.Common
{
    /// <summary>
    /// Base entity.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Id.
        /// </summary>
        public virtual long Id { get; set; }
    }
}