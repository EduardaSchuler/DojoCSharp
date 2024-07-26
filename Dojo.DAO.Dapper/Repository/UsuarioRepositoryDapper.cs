using System.Data;
using Dapper;
using Dojo.DAO.Dapper.BaseRepository;
using Dojo.DAO.Dapper.Model;

namespace Dojo.DAO.Dapper.Repository;

public class UsuarioRepositoryDapper : BaseRepositoryDapper<UsuarioDapper>, IUsuarioRepositoryDapper
{
    public UsuarioRepositoryDapper(IDbConnection connection) : base(connection)
    {

    }

    public async Task<IEnumerable<UsuarioDapper>> GetAll()
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

        return await base.GetAll(selectQuery);
    }

    public async Task<UsuarioDapper?> GetById(int id)
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

        return await base.GetById(id, selectQuery);
    } 

    public async Task Add(UsuarioDapper usuario)
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

        await base.Add(parameters, insertQuery);
    }

    public async Task Update(UsuarioDapper usuario)
    {
        const string updateQuery = @"UPDATE USUARIOS SET
                                    NOME = @Nome
                                    CPF = @Cpf
                                    EMAIL = @Email
                                    DATA_NASCIMENTO = @DataNascimento
                                    DATA_CADASTRO = @DataCadastro
                                    ATIVO = @Ativo";

        await base.Update(usuario, updateQuery);
    }

    public async Task Delete(int id)
    {
        const string deleteQuery = @"DELETE FROM USUARIOS
                                    WHWERE ID = @Id";
        await base.Delete(id, deleteQuery);
    }

}