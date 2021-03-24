using EfCoreCrud.Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCrud.Business.ValidationRules.FluentValidation
{
    public class PictureValidator : AbstractValidator<Picture>
    {
        public PictureValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("title can not be empty");
            RuleFor(p => p.ImageUrl).NotEmpty().WithMessage("image can not be empty");
            RuleFor(p => p.ProductId).GreaterThan(0).When(i => i.ProductId > 0);
        }
    }
}
