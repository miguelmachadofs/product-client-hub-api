using FluentValidation;
using ProductClientHub.Communication.Request;

namespace ProductClientHub.API.UseCases.Products.SharedValidator
{
    public class RequestProductValidator : AbstractValidator<RequestProductJson>
    {
        public RequestProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Nome não pode ser vazio.");
            RuleFor(product => product.Brand).NotEmpty().WithMessage("Marca não pode ser vazia.");
            RuleFor(product => product.Price).GreaterThan(0).WithMessage("Preço deve ser maior do que zero.");
        }
    }
}
