namespace Sale.Domain.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime Dat_Nascimento { get; set; }
    public DateTime Dat_Criacao { get; set; }
    public DateTime? Dat_Alteracao { get; set; }
    public DateTime? Dat_Exclusao { get; set; }
    public int Criado_Por_Usu_Id { get; set; }
    public int? Alterado_Por_Usu_Id { get; set; }
    public int? Excluido_Por_Usu_Id { get; set; }
    public bool Ind_Ativo { get; set; }

}

