using Sale.Domain.Models;

namespace Sale.Application.Interfaces;

public interface ISaleService
{
    Task AddAsync(Vendas_Produto venda);
    Task<Vendas_Produto> GetByProductNameAsync(string product_name);
    Task<List<Produto>> GetBySaleIdAsync(int sale_id);
}
