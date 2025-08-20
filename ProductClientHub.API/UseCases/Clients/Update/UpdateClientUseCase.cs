using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Request;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.UseCases.Clients.Update
{
    public class UpdateClientUseCase
    {
        public void Execute(Guid clientId, RequestClientJson request)
        {
            Validate(request);

            var dbContext = new ProductClientHubDbContext();

            var entity = dbContext.Clients.FirstOrDefault(client => client.Id == clientId) ?? throw new NotFoundException("Cliente não encontrado.");

            entity.Name = request.Name;
            entity.Email = request.Email;

            dbContext.Update(entity);
            dbContext.SaveChanges();
        }

        private static void Validate(RequestClientJson request)
        {
            var validator = new RequestClientValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
