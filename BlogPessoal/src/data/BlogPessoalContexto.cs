﻿using BlogPessoal.src.model;
using BlogPessoal.src.modelos;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.src.data
{
    /// <summary>
    /// <para>Resumo: Classe contexto, responsavel por carregar contexto e definir DbSets</para>
    /// <para>Criado por: Thamires Freitas</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 13/05/2022</para>
    /// </summary>
    public class BlogPessoalContexto : DbContext
    {
        public DbSet<UsuarioModelo> Usuario { get; set; }
        public DbSet<TemaModelo> Temas { get; set; }
        public DbSet<PostagemModelo> Postagens { get; set; }

       public BlogPessoalContexto(DbContextOptions<BlogPessoalContexto> opt) : base(opt)
        {

        }
    }
}
