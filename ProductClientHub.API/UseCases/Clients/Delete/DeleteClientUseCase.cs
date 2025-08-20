using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.UseCases.Clients.Delete
{
    public class DeleteClientUseCase
    {
        public void Execute(Guid clientId)
        {
            var dbContext = new ProductClientHubDbContext();

            var entity = dbContext.Clients.FirstOrDefault(client => client.Id == clientId) ?? throw new NotFoundException("Cliente não encontrado.");
            
            dbContext.Clients.Remove(entity);

            dbContext.SaveChanges();
        }
    }
}
