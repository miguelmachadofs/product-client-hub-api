using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Response;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.UseCases.Clients.GetById
{
    public class GetClientByIdUseCase
    {
        public ResponseClientJson Execute(Guid clientId)
        {
            var dbContext = new ProductClientHubDbContext();

            var entity = dbContext
                .Clients
                .Include(client => client.Products) // Carrega os produtos relacionados ao cliente (o EF faz um JOIN com a tabela Products internamente)
                .FirstOrDefault(client => client.Id == clientId) ?? throw new NotFoundException("Cliente não encontrado.");

            return new ResponseClientJson
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Products = [..entity.Products.Select(product => new ResponseShortProductJson
                {
                    Id = product.Id,
                    Name = product.Name,
                })]
            };
        }
    }
}
