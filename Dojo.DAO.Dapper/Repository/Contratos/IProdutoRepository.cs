using Dojo.DAO.Dapper.Model;

namespace Dojo.DAO.Dapper.Repository.Contratos;

public interface IProdutoRepository
{
    Task<IEnumerable<UsuarioDapper>> ListaProduto();

    Task<UsuarioDapper?> ObtemProdutoPorId(int id);

    Task AdicionaProduto(Produto produto);

    Task AtualizaProduto(Produto produto);

    Task DeletaProduto(int id);
}