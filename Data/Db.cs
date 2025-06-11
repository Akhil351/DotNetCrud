using crud.Model;
using Microsoft.EntityFrameworkCore;
using crud.Model;

namespace crud.Data;

public class Db(DbContextOptions<Db> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
}