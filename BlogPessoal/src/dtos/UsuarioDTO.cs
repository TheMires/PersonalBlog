using BlogPessoal.src.utilidades;
using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.src.dtos
{
    public class NovoUsuarioDTO
    {
        [Required, StringLength(50)]
        public string Nome { get; set; }

        [Required, StringLength(30)]
        public string Email { get; set; }

        [Required, StringLength(30)]
        public string Senha { get; set; }

        public string Foto { get; set; }

        [Required]
        public TipoUsuario Tipo { get; set; }

        public NovoUsuarioDTO(string nome, string email, string senha, string foto, TipoUsuario tipo) 
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Foto = foto;
            Tipo = tipo;
        }
    }

    public class AtualizarUsuarioDTO

    {
        [Required, StringLength(50)]
        public string Nome { get; set; }

        [Required, StringLength(30)]
        public string Senha { get; set; }

        public string Foto { get; set; }

        [Required]
        public TipoUsuario Tipo { get; set; }

        [Required]
        public int Id { get; set; }

        /// <summary>
        /// <para>Resumo: Classe espelho para alterar um novo usuario</para>
        /// <para>Criado por: Thamires Freitas</para>
        /// <para>Versão: 1.0</para>
        /// <para>Data: 29/04/2022</para>
        /// </summary>

        public AtualizarUsuarioDTO(int v, string nome, string senha, string foto)
        {
            Nome = nome;
            Senha = senha;
            Foto = foto;
        }
    }
}
