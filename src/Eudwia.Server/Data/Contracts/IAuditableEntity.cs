namespace Eudwia.Server.Data.Contracts;

public interface IAuditableEntity
{
    DateTime AuditCreatedAt { get; set; } 
    string AuditCreatedBy { get; set; }
    DateTime AuditModifiedAt { get; set; }
    string AuditModifiedBy { get; set; }
}