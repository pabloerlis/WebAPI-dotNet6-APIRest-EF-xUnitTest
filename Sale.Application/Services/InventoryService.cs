using Sale.Application.Interfaces;
using Sale.Domain.Contracts;
using Sale.Domain.Models;

namespace Sale.Application.Services;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;

    public InventoryService(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<Estoque> GetByProductNameAsync(int product_id)
    {
        return await _inventoryRepository.GetByProductNameAsync(product_id);
    }
}
