namespace Dojo.DAO.Dapper.Model;

public class Produto
{
    public int Id { get; set; }

    public string ProdutoNome { get; set; } = null!;

    public double Preco { get; set; }

    public string Cor { get; set; } = null!;

    public bool Ativo { get; set; }
}