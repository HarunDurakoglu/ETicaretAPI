using ETicaretAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator:AbstractValidator<Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                        .NotEmpty()
                        .NotNull().WithMessage("Lütfen ürün adını boş geçmeyiniz")
                        .MaximumLength(150)
                        .MinimumLength(2)
                        .WithName("Ürün adı 2-150 karakter aralığında olmalıdır");

            RuleFor(p => p.Stock)
                        .NotEmpty()
                        .NotNull()
                        .WithName("Lütfen stok bilgisi giriniz")
                        .Must(s => s >= 0)
                        .WithName("Stok bilgisi eksi olamaz");

            RuleFor(p => p.Price)
                        .NotEmpty()
                        .NotNull()
                        .WithName("Lütfen fiyat bilgisi giriniz")
                        .Must(s => s >= 0)
                        .WithName("Fiyat bilgisi eksi olamaz");
        }
    }
}
