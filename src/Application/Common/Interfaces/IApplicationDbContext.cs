using TPProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TPProject.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Supplier> Suppliers { get; }
    DbSet<Brand> Brands { get; }
    DbSet<Category> Categories { get; }
    DbSet<Product> Products { get; }
    DbSet<Invoice> Invoices { get; }
    DbSet<InvoiceDetail> InvoiceDetails { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
