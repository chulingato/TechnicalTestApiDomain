using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestApi.Domain;


namespace TechnicalTestApi.Application.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.name)
                .NotEmpty().WithMessage("El nombre es requerido")
                .NotNull().WithMessage("El nombre es requerido");

            RuleFor(product => product.price)
                .NotNull().WithMessage("El precio es requerido")
                .GreaterThan(0).WithMessage("El precio debe ser mayor a cero")
                .ScalePrecision(2, 10).WithMessage("El precio debe tener un máximo de 10 dígitos y 2 decimales");

            RuleFor(product => product.stock)
                .NotNull().WithMessage("El stock es requerido")
                .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo");
            
        }
    }
}
