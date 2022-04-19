using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TPProject.Application.Common.Interfaces;

namespace TPProject.Application.Brands.Commands.UpdateBrand;

public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdateBrandCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.BrandName)
            .MaximumLength(200)
            .MustAsync(BeUniqueBrand).WithMessage("The specified brand already exists.")
            .NotEmpty().WithMessage("Brand name should not be empty."); ;
        RuleFor(v => v.ShortName)
            .MaximumLength(100)
            .NotEmpty();
    }
    public async Task<bool> BeUniqueBrand(string brand, CancellationToken cancellationToken)
    {
        return await _context.Brands
            .AllAsync(l => l.BarandName != brand, cancellationToken);
    }
}
