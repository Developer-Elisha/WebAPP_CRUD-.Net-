using CRUD_AspDotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_AspDotNet.DB_Context
{
    public class SqlContext : DbContext
   {
      public SqlContext(DbContextOptions<SqlContext> option) : base(option)
    {

    }
    public DbSet<User> tblusers { get; set; }
}
}
