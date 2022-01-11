namespace DesktopClearArchitecture.Domain.Entities
{
    using Common;

    /// <summary>
    /// Product.
    /// </summary>
    public class Product : AuditableEntity
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }
    }
}