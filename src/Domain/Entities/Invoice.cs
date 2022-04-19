namespace TPProject.Domain.Entities;
public class Invoice : AuditIdentityEntity
{
    public int InvoiceNumber { get; set; }
    public Supplier SupplierOrder { get; set; } = new Supplier();
    public decimal Total { get; set; }
}
