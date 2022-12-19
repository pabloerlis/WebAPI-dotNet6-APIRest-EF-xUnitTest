using Sale.Domain.Models;

namespace Sale.Domain.Contracts;

public interface ISaleRepository
{
    Task AddAsync(Vendas_Produto venda);
    Task<Vendas_Produto> GetByProductNameAsync(string product_name);
    Task<List<Produto>> GetBySaleIdAsync(int sale_id);
}
