﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;
using Microsoft.EntityFrameworkCore;

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

        public async Task<UsuarioModelo> PegarUsuarioPeloIdAsync(int id)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<UsuarioModelo>> PegarUsuariosPeloNomeAsync(string nome)
        {
            return await _context.Usuario
                        .Where(u => u.Nome.Contains(nome))
                        .ToListAsync();
        }

        public async Task<UsuarioModelo> PegarUsuarioPeloEmailAsync(string email)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task NovoUsuarioAsync(NovoUsuarioDTO usuario)
        {
            await _context.Usuario.AddAsync(
            new UsuarioModelo
            {
                Email = usuario.Email,
                Nome = usuario.Nome,
                Senha = usuario.Senha,
                Foto = usuario.Foto,
                Tipo = usuario.Tipo
            }) ;
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarUsuarioAsync(AtualizarUsuarioDTO usuario)
        {
            var usuarioExistente = await PegarUsuarioPeloIdAsync(usuario.Id);
            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Senha = usuario.Senha;
            usuarioExistente.Foto = usuario.Foto;
            _context.Usuario.Update(usuarioExistente);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarUsuarioAsync(int id)
        {
            _context.Usuario.Remove(await PegarUsuarioPeloIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public List<UsuarioModelo> PegarUsuarioPeloNome(string nome)
        {
            throw new System.NotImplementedException();
        }

        #endregion Métodos
    }
}