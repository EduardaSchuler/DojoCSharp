using Dojo.DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace Dojo.Test;

public class MockDbContext : DbdojoContext
{
	public MockDbContext()
	{
	}

	public MockDbContext(DbContextOptions<DbdojoContext> options)
			: base(options)
	{
	}

	public DbSet<Usuario> Users { get; set; }

}