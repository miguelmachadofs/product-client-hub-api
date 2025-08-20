using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.UseCases.Products.Delete
{
    public class DeleteProductUseCase
    {
        public void Execute(Guid productId)
        {
            var dbContext = new ProductClientHubDbContext();

            var entity = dbContext.Products.FirstOrDefault(product => product.Id == productId) ?? throw new NotFoundException("Produto não encontrado.");
            
            dbContext.Products.Remove(entity);

            dbContext.SaveChanges();
        }
    }
}
