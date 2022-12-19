using MasterChef.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Sale.Domain.Contracts;
using Sale.Domain.Models;

namespace Sale.Persistence.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private DataContext _dataContext;
    public InventoryRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Estoque> GetByProductNameAsync(int product_id)
    {
        return await _dataContext.ESTOQUE.FirstOrDefaultAsync(e => e.ProdutoId == product_id);
    }
}
