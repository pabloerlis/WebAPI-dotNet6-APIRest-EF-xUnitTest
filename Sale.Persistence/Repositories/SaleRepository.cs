using MasterChef.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Sale.Domain.Contracts;
using Sale.Domain.Models;

namespace Sale.Persistence.Repositories;

public class SaleRepository : ISaleRepository
{
    private DataContext _dataContext;
    public SaleRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Vendas_Produto>  GetByProductNameAsync(string product_name)
    {
        var query = await _dataContext.VENDAS_PRODUTOS
            .Join(_dataContext.PRODUTOS,
                vendas => vendas.ProdutoId,
                produto => produto.Id,
                (vendas, produto) => new { Vendas = vendas, Produto = produto })
            .Where(produto => produto.Produto.Nome.Equals(product_name))
            .Select(v => new Vendas_Produto()
            {
                Id = v.Vendas.Id,
                VendaId = v.Vendas.VendaId,
                ProdutoId = v.Vendas.ProdutoId,
                Valor = v.Vendas.Valor,
                Desconto = v.Vendas.Desconto,
                Valor_Final = v.Vendas.Valor_Final,
                Dat_Criacao = v.Vendas.Dat_Criacao,
                Dat_Alteracao = v.Vendas.Dat_Alteracao,
                Dat_Exclusao = v.Vendas.Dat_Exclusao,
                Criado_Por_Usu_Id = v.Vendas.Criado_Por_Usu_Id,
                Alterado_Por_Usu_Id = v.Vendas.Alterado_Por_Usu_Id,
                Excluido_Por_Usu_Id = v.Vendas.Excluido_Por_Usu_Id

            }).FirstOrDefaultAsync();


        return query;

    }

    public async Task AddAsync(Vendas_Produto vendas_Produto)
    {
        var venda = new Venda
        {
            Dat_Criacao = DateTime.Now,
            Criado_Por_Usu_Id = vendas_Produto.Criado_Por_Usu_Id,
            Ind_Ativo = true
        };

        await InsertSale(venda);

        await _dataContext.VENDAS_PRODUTOS.AddAsync(vendas_Produto);
        await _dataContext.SaveChangesAsync();
    }

    public async Task InsertSale(Venda venda)
    {
        _dataContext.VENDAS.Add(venda);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<List<Produto>> GetBySaleIdAsync(int sale_id) 
    {
        var query = await _dataContext.VENDAS_PRODUTOS
           .Join(_dataContext.PRODUTOS,
               vendas => vendas.ProdutoId,
               produto => produto.Id,
               (vendas, produto) => new { Vendas = vendas, Produto = produto })
           .Where(produto => produto.Vendas.VendaId == sale_id)
           .Select(p => new Produto()
           {
               Id = p.Produto.Id,
               Nome = p.Produto.Nome
           }).ToListAsync();


        return query;
    }
}
