namespace Sale.Domain.Models;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public DateTime Dat_Criacao { get; set; }
    public DateTime? Dat_Alteracao { get; set; }
    public DateTime? Dat_Exclusao { get; set; }
    public int Criado_Por_Usu_Id { get; set; }
    public int? Alterado_Por_Usu_Id { get; set; }
    public int? Excluido_Por_Usu_Id { get; set; }
    public bool Ind_Ativo { get; set; }
    public List<Estoque> Estoque { get; set; }
    public List<Vendas_Produto> Vendas_Produto { get; set; }
}
