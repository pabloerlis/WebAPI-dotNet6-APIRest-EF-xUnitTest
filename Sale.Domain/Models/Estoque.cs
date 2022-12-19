using System.ComponentModel.DataAnnotations.Schema;

namespace Sale.Domain.Models;

public class Estoque
{
    public int Id { get; set; }

    [ForeignKey("FK_Produto")]
    public int ProdutoId { get; set; }
    public int Nm_Quantidade { get; set; }
    public bool Ind_Ativo { get; set; }
}
