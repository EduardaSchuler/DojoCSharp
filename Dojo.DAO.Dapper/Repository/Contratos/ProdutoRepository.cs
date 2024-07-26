using System.Data;
using Dapper;
using Dojo.DAO.Dapper.BaseRepository;
using Dojo.DAO.Dapper.Model;

namespace Dojo.DAO.Dapper.Repository.Contratos;

public class ProdutoRepository : BaseRepositoryDapper<UsuarioDapper>, IProdutoRepository
{
    public ProdutoRepository(IDbConnection connection) : base(connection)
    {
    }

    public async Task<IEnumerable<UsuarioDapper>> ListaProduto()
    {
        const string selectQuery = @"SELECT 
                                        ID, 
                                        PRODUTO_NOME AS ProdutoNome, 
                                        PRECO, 
                                        COR, 
                                        ATIVO 
                                    FROM PRODUTOS";

        return await ListaTodos(selectQuery);
    }

    public async Task<UsuarioDapper?> ObtemProdutoPorId(int id)
    {
        const string selectQuery = @"SELECT 
                                    ID, 
                                    PRODUTO_NOME AS ProdutoNome, 
                                    PRECO, 
                                    COR, 
                                    ATIVO 
                                FROM PRODUTOS
                                WHERE ID = @Id";

        return await ObtemPorId(id, selectQuery);
    }

    public async Task AdicionaProduto(Produto produto)
    {
        const string insertQuery = @"INSERT INTO PRODUTOS
                                        PRODUTOS (PRODUTO_NOME, PRECO, COR ATIVO)
                                        VALUES (@ProdutoNome, @Cor, @Preco, @Ativo)";

        var parameters = new DynamicParameters();
        parameters.Add("@NomeProduto", new DbString { Value = produto.ProdutoNome, IsFixedLength = true, Length = 50, IsAnsi = true});
        parameters.Add("@Cor", new DbString { Value = produto.Cor , IsFixedLength = true, Length = 20, IsAnsi = true });
        parameters.Add("@Preco", produto.Preco);
        parameters.Add("@Ativo", produto.Ativo);

        await Adiciona(parameters, insertQuery);
    }

    public async Task AtualizaProduto(Produto produto)
    {
        const string updateQuery = @"UPDATE PRODUTOS SET
                                        PRODUTO_NOME = @ProdutoNome,
                                        PRECO = @Preco,
                                        COR = @Cor,
                                        ATIVO = @Ativo,
                                    WHERE ID = @Id";

        var parameters = new DynamicParameters();
        parameters.Add("@Id", produto.Id);
        parameters.Add("@ProdutoNome", new DbString { Value = produto.ProdutoNome, IsFixedLength = true, Length = 50, IsAnsi = true});
        parameters.Add("@Cor", new DbString { Value = produto.Cor , IsFixedLength = true, Length = 20, IsAnsi = true });
        parameters.Add("@Preco", produto.Preco);
        parameters.Add("@Ativo", produto.Ativo);

        await Atualiza(parameters, updateQuery);
    }

    public async Task DeletaProduto(int id)
    {
        const string deleteQuery = @"DELETE FROM PRODUTOS
                                    WHERE ID = @Id";
        await Deleta(id, deleteQuery);
    }
}