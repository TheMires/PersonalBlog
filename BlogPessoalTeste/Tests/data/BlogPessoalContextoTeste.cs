using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogPessoal.src.data;
using Microsoft.EntityFrameworkCore;
using BlogPessoal.src.modelos;
using System.Linq;

namespace BlogPessoalTeste.Tests.data
{
    [TestClass]
    public class BlogPessoalContextoTeste
    {
        private BlogPessoalContexto _context;

        [TestInitialize]
        public void setup()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "db_blogpessoal")
                .Options;

            _context = new BlogPessoalContexto(opt);
        }

        [TestMethod]
        public void InserirNovoUsuarioNoBancoRetornarUsuario()
        {
            UsuarioModelo user = new UsuarioModelo();
            user.Nome = "Thamires Aparecida";
            user.Email = "thamiresa@email.com";
            user.Senha = "123456";
            user.Foto = "LINKDAFOTO";

            _context.Usuarios.Add(user); // adicionando usuario

            _context.SaveChanges(); // comita criação

            Assert.IsNotNull(_context.Usuarios.FirstOrDefault(u => u.Email == "thamiresa@email.com"));
        }
    }
}
