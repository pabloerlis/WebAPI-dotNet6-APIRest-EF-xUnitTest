using Sale.Domain.Models;

namespace Sale.Domain.Contracts;

public interface IInventoryRepository
{
    Task<Estoque> GetByProductNameAsync(int product_id);
}
