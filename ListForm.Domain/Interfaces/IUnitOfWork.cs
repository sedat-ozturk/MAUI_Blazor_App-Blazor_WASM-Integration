namespace ListForm.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
    }
}
