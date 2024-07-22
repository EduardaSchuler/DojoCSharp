namespace Dojo.DAO.Dapper.Model;

public class UsuarioDapper
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;
    
    public string Email { get; set; } = null!;

    public DateTime DataNascimento { get; set; }

    public DateTime DataCadastro { get; set; }

    public byte Ativo { get; set; }
}