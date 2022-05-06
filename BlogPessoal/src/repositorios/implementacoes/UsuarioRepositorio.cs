using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;
using System.Collections.Generic;
using System.Linq;

namespace BlogPessoal.src.repositorios.implementacoes
{
    public class UsuarioRepositorio : IUsuario
    {
        #region Atributos

        private readonly BlogPessoalContexto _context;

        #endregion Atributos

        #region Construtores
        public UsuarioRepositorio(BlogPessoalContexto contexto)
        {
            _context = contexto;
        }
        #endregion Construtores
        #region Métodos

        public void AtualizarUsuario(AtualizarUsuarioDTO usuario)
        {
            var usuarioExistente = PegarUsuarioPeloId(usuario.Id);
            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Senha = usuario.Senha;
            usuarioExistente.Foto = usuario.Foto;
            _context.Usuario.Update(usuarioExistente);
            _context.SaveChanges();
        }

        public void DeletarUsuario(int id)
        {
            _context.Usuario.Remove(PegarUsuarioPeloId(id));
            _context.SaveChanges();
        }

        public void NovoUsuario(NovoUsuarioDTO Usuario)
        {
            _context.Usuario.Add(new UsuarioModelo
            {
                Email = Usuario.Email,
                Nome = Usuario.Nome,
                Senha = Usuario.Senha,
                Foto = Usuario.Foto
            });
            _context.SaveChanges();
        }

        public UsuarioModelo PegarUsuarioPeloEmail(string email)
        {
            return _context.Usuario.FirstOrDefault(u => u.Email == email);
        }

        public UsuarioModelo PegarUsuarioPeloId(int id)
        {
            return _context.Usuario.FirstOrDefault(u => u.Id == id);
        }

        public List<UsuarioModelo> PegarUsuarioPeloNome(string nome)
        {
            return _context.Usuario.Where(u => u.Nome.Contains(nome)).ToList();
        }

        #endregion Métodos
    }
}