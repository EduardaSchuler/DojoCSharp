namespace Dojo.DAO.Context;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public DateTime DataNascimento { get; set; }

    public DateTime DataCadastro { get; set; }

    public byte Ativo { get; set; }
}
