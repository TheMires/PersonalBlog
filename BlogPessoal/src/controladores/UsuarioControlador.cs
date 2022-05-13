using BlogPessoal.src.dtos;
using BlogPessoal.src.repositorios;
using BlogPessoal.src.servicos.BlogPessoal.src.servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlogPessoal.src.controladores

{
    [ApiController]

    [Route("api/Usuarios")]
    [Produces("application/json")]

    public class UsuarioControlador : ControllerBase
    {
        #region Atributos

        private readonly IUsuario _repositorio;
        private readonly IAutenticacao _servicos;

        #endregion

        #region Construtores
        public UsuarioControlador(IUsuario repositorio, IAutenticacao servicos)
        {
            _repositorio = repositorio;
            _servicos = servicos;
        }
        #endregion

        #region Métodos

        [HttpGet("id/{idUsuario}")]
        [Authorize(Roles ="NORMAL,ADMINISTRADOR")]
        public async Task<ActionResult> PegarUsuarioPeloIdAsync([FromRoute] int idUsuario)
        {
            var usuario = await _repositorio.PegarUsuarioPeloIdAsync(idUsuario);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpGet]
        [Authorize(Roles = "NORMAL,ADMINISTRADOR")]
        public async Task<ActionResult> PegarUsuariosPeloNomeAsync([FromQuery] string nomeUsuario)
        {
            var usuario = await _repositorio.PegarUsuariosPeloNomeAsync(nomeUsuario);
            if (usuario.Count < 1) return NoContent();
            return Ok(usuario);
        }

        [HttpGet("email/{emailUsuario}")]
        [Authorize(Roles = "NORMAL,ADMINISTRADOR")]
        public async Task<ActionResult> PegarUsuarioPeloEmailAsync([FromRoute] string emailUsuario)
        {
            var usuario = await _repositorio.PegarUsuarioPeloEmailAsync(emailUsuario);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> NovoUsuarioAsync([FromBody] NovoUsuarioDTO usuario)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _repositorio.NovoUsuarioAsync(usuario);
            return Created($"api/Usuarios/{usuario.Email}", usuario);
        }

        [HttpPut]
        [Authorize(Roles = "NORMAL,ADMINISTRADOR")]
        public async Task<ActionResult> AtualizarUsuarioAsync([FromBody] AtualizarUsuarioDTO
        usuario)
        {
            if (!ModelState.IsValid) return BadRequest();

            usuario.Senha = _servicos.CodificarSenha(usuario.Senha);

            await _repositorio.AtualizarUsuarioAsync(usuario);
            return Ok(usuario);
        }

        [HttpDelete("deletar/{idUsuario}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public async Task<ActionResult> DeletarUsuarioasync([FromRoute] int idUsuario)
        {
            await _repositorio.DeletarUsuarioAsync(idUsuario);
            return NoContent();
        }
        #endregion
    }
}