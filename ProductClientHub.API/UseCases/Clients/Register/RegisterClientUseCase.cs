using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Request;
using ProductClientHub.Communication.Response;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {
        public ResponseShortClientJson Execute(RequestClientJson request)
        {
            Validate(request);

            var dbContext = new ProductClientHubDbContext();

            var entity = new Client
            {
                Name = request.Name,
                Email = request.Email
            };

            dbContext.Clients.Add(entity);

            dbContext.SaveChanges();

            return new ResponseShortClientJson
            {
                Id = entity.Id,
                Name = entity.Name
            };
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
