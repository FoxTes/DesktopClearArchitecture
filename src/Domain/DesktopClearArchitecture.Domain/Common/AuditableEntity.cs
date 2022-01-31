namespace DesktopClearArchitecture.Domain.Common;

using System;

/// <summary>
/// Auditable entity.
/// </summary>
public abstract class AuditableEntity : BaseEntity
{
    /// <summary>
    /// Create by.
    /// </summary>
    public string CreatedBy { get; set; }

    /// <summary>
    /// Data created.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Last modified by.
    /// </summary>
    public string LastModifiedBy { get; set; }

    /// <summary>
    /// Data last modified.
    /// </summary>
    public DateTime? LastModified { get; set; }
}