using blog_orm_structure_with_ef.Models;
using Microsoft.EntityFrameworkCore;

/* DataContext é o único modelo que o Entity Framework precisa! ele define o 
banco de dados em memória, uma representação dos dados na memória */
namespace blog_orm_structure_with_ef.Data
{
    /* DbSet são subconjuntos do DataContext, ele representa as tabelas do 
    seu banco de dados! */
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        // public DbSet<PostTag> PostTags { get; set; } //=> possuí chave composta
        public DbSet<Role> Rules { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        // public DbSet<UserRole> UserRoles { get; set; } //=> possuí chave composta

        /* configura a connection string, quando classe é instanciada já é identificada! */
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;");
    }
}