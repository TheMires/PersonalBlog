﻿using BlogPessoal.src.dtos;
using BlogPessoal.src.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPessoal.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de postagem</para>
    /// <para>Criado por: Thamires Freitas</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 13/05/2022</para>
    /// </summary>
    
    public interface IPostagem
    {
        Task<List<PostagemModelo>> PegarTodasPostagensAsync();
        Task<PostagemModelo> PegarPostagemPeloIdAsync(int id);
        Task<List<PostagemModelo>> PegarPostagensPorPesquisaAsync(string titulo, string descricaoTema, string nomeCriador);
        Task NovaPostagemAsync(NovaPostagemDTO postagem);
        Task AtualizarPostagemAsync(AtualizarPostagemDTO postagem);
        Task DeletarPostagemAsync(int id);
    }
}
