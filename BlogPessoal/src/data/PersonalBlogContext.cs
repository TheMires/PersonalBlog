using BlogPessoal.src.model;
using BlogPessoal.src.modelos;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.src.data
{
    public class PersonalBlogContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ThemeModel> Themes { get; set; }
        public DbSet<PostModel> Posts { get; set; }

       public PersonalBlogContext(DbContextOptions<PersonalBlogContext> opt) : base(opt)
        {

        }
    }
}
