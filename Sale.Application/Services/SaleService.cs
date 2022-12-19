using Sale.Application.Interfaces;
using Sale.Domain.Contracts;
using Sale.Domain.Models;

namespace Sale.Application.Services;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _saleRepository;

    public SaleService(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task AddAsync(Vendas_Produto venda)
    {
        await _saleRepository.AddAsync(venda);
    }


    public async Task<Vendas_Produto> GetByProductNameAsync(string product_name)
    {
        return await _saleRepository.GetByProductNameAsync(product_name);
    }

    public async Task<List<Produto>> GetBySaleIdAsync(int sale_id)
    {
        return await _saleRepository.GetBySaleIdAsync(sale_id);
    }
}
