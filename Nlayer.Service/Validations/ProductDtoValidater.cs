using FluentValidation;
using Nlayer.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Service.Validations
{
    public class ProductDtoValidater:AbstractValidator<ProductDto>
    {
        public ProductDtoValidater()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be grater than 0");
            RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be grater than 0");
            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be grater than 0");
        }
    }
}
