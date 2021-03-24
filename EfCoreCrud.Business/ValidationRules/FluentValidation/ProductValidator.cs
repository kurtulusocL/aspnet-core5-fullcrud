using EfCoreCrud.Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCrud.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("name can not be empty");
            RuleFor(p => p.Name).MinimumLength(2);
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.Stock).NotEmpty();
            RuleFor(p => p.CategoryId).GreaterThan(0).When(i => i.CategoryId > 0);
        }
    }
}
