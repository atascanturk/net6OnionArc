using FluentValidation;
using net6OnionArc.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Application.Validators
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen ürün adını boş geçmeyiniz.");

            RuleFor(x => x.Name).MaximumLength(150).WithMessage("Lütfen ürün adını 5 ile 150 karakter arasında giriniz.").MaximumLength(5).WithMessage("Lütfen ürün adını 5 ile 150 karakter arasında giriniz.");

            RuleFor(x => x.Stock).NotEmpty().WithMessage("Lütfen stok bilgisini boş geçmeyiniz.").NotNull().WithMessage("Lütfen stok bilgisini boş geçmeyiniz.");

            RuleFor(x => x.Stock).Must(x => x >= 0).WithMessage("Stok bilgisi negatif olamaz.");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz.").NotNull().WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz.");

            RuleFor(x => x.Price).Must(x => x >= 0).WithMessage("Fiyat bilgisi negatif olamaz.");
        }
    }
}
