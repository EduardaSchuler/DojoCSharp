
using Microsoft.EntityFrameworkCore;

namespace Dojo.DAO.BaseRepository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _context; // objeto de conexão do banco de dados e a aplicação

    public BaseRepository(DbContext context)
    {
        _context = context;
    }

    //metodos assincronos 

    public async Task AddAsync(TEntity entity) 
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync(); // para metodos de metodos que vao modificar algo no banco deve-se usar este metodo sendo Async ou não
    }

    public async Task DeleteAsync(int id) 
    {
        var entity = await GetByIdAsync(id);
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() 
    => await _context.Set<TEntity>().ToListAsync();

    //TO DO: Acertar o null reference nesse metodo
    public async Task<TEntity> GetByIdAsync(int id)
    => await _context.Set<TEntity>().FindAsync(id);

}