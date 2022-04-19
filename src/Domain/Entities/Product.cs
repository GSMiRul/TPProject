namespace TPProject.Domain.Entities;
public class Product : AuditIdentityEntity
{
    public string? ProductName { get; set; }
    public Category ProductCategory { get; set; } = new Category();
    public string? Description { get; set; }

}
