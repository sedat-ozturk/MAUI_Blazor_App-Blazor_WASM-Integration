namespace ListForm.Api.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
    }
}
