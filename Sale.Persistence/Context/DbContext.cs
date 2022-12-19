using Microsoft.EntityFrameworkCore;
using Sale.Domain.Models;

namespace MasterChef.Persistence.Context;

public class DataContext : DbContext
{
    public DataContext()
      : base()
    {

    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {

    }

    public DbSet<Estoque> ESTOQUE { get; set; }
    public DbSet<Produto> PRODUTOS { get; set; }
    public DbSet<Usuario> USUARIOS { get; set; }
    public DbSet<Venda> VENDAS { get; set; }
    public DbSet<Vendas_Produto> VENDAS_PRODUTOS { get; set; }

}
