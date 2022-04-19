namespace TPProject.Domain.Entities;
public class InventoryList
{
    public Brand ProductBrand { get; set; } = new Brand();
    public List<Product> Products { get; set; } = new List<Product>();
    public int Quantity { get { return Products.DefaultIfEmpty().Count(); } }
}
