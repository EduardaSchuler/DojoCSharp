using System.Data;
using Dapper;
using Dojo.DAO.Dapper.BaseRepository;
using Dojo.DAO.Dapper.Model;

namespace Dojo.DAO.Dapper.Repository.Contratos;

public class UsuarioRepositoryDapper : BaseRepositoryDapper<UsuarioDapper>, IUsuarioRepositoryDapper
{
    public UsuarioRepositoryDapper(IDbConnection connection) : base(connection)
    {

    }

    public async Task<IEnumerable<UsuarioDapper>> ListaUsuarios()
    {
        const string selectQuery = @"SELECT
                                        ID,
                                        NOME, 
                                        CPF, 
                                        EMAIL, 
                                        DATA_NASCIMENTO, 
                                        DATA_CADASTRO, 
                                        ATIVO
                                    FROM USUARIOS";

        return await ListaTodos(selectQuery);
    }

    public async Task<UsuarioDapper?> ObtemUsuarioPorId(int id)
    {
        const string selectQuery = @"SELECT
                                        ID,
                                        NOME, 
                                        CPF, 
                                        EMAIL, 
                                        DATA_NASCIMENTO, 
                                        DATA_CADASTRO, 
                                        ATIVO
                                    FROM USUARIOS
                                    WHERE ID = @Id";

        return await ObtemPorId(id, selectQuery);
    } 

    public async Task AdicionaUsuario(UsuarioDapper usuario)
    {
        const string insertQuery = @"INSERT INTO 
                                        USUARIOS(NOME, CPF, EMAIL, DATA_NASCIMENTO, DATA_CADASTRO, ATIVO) 
                                        VALUES(@Nome, @Cpf, @Email, @DataNascimento, @DataCadastro, @Ativo)";

        var parameters = new DynamicParameters();
        parameters.Add("@Nome", new DbString { Value = usuario.Nome, IsFixedLength = true, Length = 80, IsAnsi = true });
        parameters.Add("@Cpf", new DbString { Value = usuario.Cpf, IsFixedLength = true, Length = 11, IsAnsi = true });
        parameters.Add("@Email", new DbString { Value = usuario.Email, IsFixedLength = true, Length = 200, IsAnsi = true });
        parameters.Add("@DataNacimento", usuario.DataNascimento);
        parameters.Add("@DataCadastro", usuario.DataCadastro);
        parameters.Add("@Ativo", usuario.Ativo);

        await Adiciona(parameters, insertQuery);
    }

    public async Task AtualizaUsuario(UsuarioDapper usuario)
    {
        const string updateQuery = @"UPDATE USUARIOS SET
                                    NOME = @Nome
                                    CPF = @Cpf
                                    EMAIL = @Email
                                    DATA_NASCIMENTO = @DataNascimento
                                    DATA_CADASTRO = @DataCadastro
                                    ATIVO = @Ativo";

        var parameters = new DynamicParameters();
        parameters.Add("@Id", usuario.Id);
        parameters.Add("@Nome", new DbString { Value = usuario.Nome, IsFixedLength = true, Length = 80, IsAnsi = true });
        parameters.Add("@Cpf", new DbString { Value = usuario.Cpf, IsFixedLength = true, Length = 11, IsAnsi = true });
        parameters.Add("@Email", new DbString { Value = usuario.Email, IsFixedLength = true, Length = 200, IsAnsi = true });
        parameters.Add("@DataNacimento", usuario.DataNascimento);
        parameters.Add("@DataCadastro", usuario.DataCadastro);
        parameters.Add("@Ativo", usuario.Ativo);

        await Atualiza(parameters, updateQuery);
    }

    public async Task DeletaUsuario(int id)
    {
        const string deleteQuery = @"DELETE FROM USUARIOS
                                    WHERE ID = @Id";
        await Deleta(id, deleteQuery);
    }

}