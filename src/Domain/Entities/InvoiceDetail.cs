namespace TPProject.Domain.Entities;
public class InvoiceDetail : AuditIdentityEntity
{
    public Invoice Invoice { get; set; } = new Invoice();
    public Brand BrandProduct { get; set; } = new Brand();
    public Product ProductInfo { get; set; } = new Product();
    public string? SerialNumber { get; set; }
    public decimal? Cost { get; set; }
    public ProductState State { get; set; } = ProductState.Unavailable;
}
