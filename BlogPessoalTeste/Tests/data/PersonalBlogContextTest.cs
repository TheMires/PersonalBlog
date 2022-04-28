using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogPessoal.src.data;
using Microsoft.EntityFrameworkCore;
using BlogPessoal.src.modelos;
using System.Linq;

namespace BlogPessoalTeste.Tests.data
{
    [TestClass]
    public class PersonalBlogContextTest
    {
        private PersonalBlogContext _context;

        [TestInitialize]
        public void setup()
        {
            var opt = new DbContextOptionsBuilder<PersonalBlogContext>()
                .UseInMemoryDatabase(databaseName: "db_blogpessoal")
                .Options;

            _context = new PersonalBlogContext(opt);
        }

        [TestMethod]
        public void InserirNovoUsuarioNoBancoRetornarUsuario()
        {
            UserModel user = new UserModel();
            user.Name = "Karol Boaz";
            user.Email = "karol@email.com";
            user.Password = "123456";
            user.Photo = "LINKDAFOTO";

            _context.Users.Add(user); // adicionando usuario

            _context.SaveChanges(); // comita criação

            Assert.IsNotNull(_context.Users.FirstOrDefault(u => u.Email == "karol@email.com"));
        }
    }
}
