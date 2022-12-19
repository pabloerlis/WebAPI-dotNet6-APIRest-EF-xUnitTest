using System.ComponentModel.DataAnnotations.Schema;

namespace Sale.Domain.Models;

public class Vendas_Produto
{
    public int Id { get; set; }

    [ForeignKey("FK_Produto")]
    public int ProdutoId { get; set; }

    [ForeignKey("FK_Venda")]
    public int VendaId { get; set; }

    public decimal Valor { get; set; }
    public decimal Desconto { get; set; }
    public decimal Valor_Final { get; set; }
    public DateTime Dat_Criacao { get; set; }
    public DateTime? Dat_Alteracao { get; set; }
    public DateTime? Dat_Exclusao { get; set; }
    public int Criado_Por_Usu_Id { get; set; }
    public int? Alterado_Por_Usu_Id { get; set; }
    public int? Excluido_Por_Usu_Id { get; set; }
    public bool Ind_Ativo { get; set; }
   
   

}
