using ListForm.Api.Application.Interfaces;

namespace ListForm.Api.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(IProductRepository productRepository)
        {
            Products = productRepository;
        }

        public IProductRepository Products { get; }
    }
}
