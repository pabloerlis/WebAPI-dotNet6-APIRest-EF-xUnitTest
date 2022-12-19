using Sale.Domain.Models;

namespace Sale.Application.Interfaces;

public interface IInventoryService
{
    Task<Estoque> GetByProductNameAsync(int product_id);
}
