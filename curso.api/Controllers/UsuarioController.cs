using curso.api.Business.Entities;
using curso.api.Business.Repositories;
using curso.api.Filters;
using curso.api.Models;
using curso.api.Models.Usuarios;
using curso.api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace curso.api.Controllers
{
    /// <summary>
    /// Controller de usuários
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthenticationService _authenticationService;

        public UsuarioController(
            IUsuarioRepository usuarioRepository,
            IAuthenticationService authenticationService)
        {
            _usuarioRepository = usuarioRepository;
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Rota que permite autenticar um usuário cadastrado
        /// </summary>      
        /// <returns>Retorna usuário e token em caso de sucesso </returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutPut))]
        [SwaggerResponse(statusCode: 500, description: "Sucesso ao autenticar", Type = typeof(ErroGenericoViewModel))]
        [HttpGet]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Logar()
        {
            var usuario = new UsuarioViewModelOutPut
            {
                Codigo = 1,
                Login = "bufaonanet",
                Email = "bufao@email.com"
            };

            var token = _authenticationService.GerarToken(usuario);

            return Ok(new
            {
                Token = token,
                Usuario = usuario
            });
        }

        /// <summary>
        /// Rota que permite Registrar um usuário 
        /// </summary>
        /// <param name="registro"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao registrar", Type = typeof(RegistroViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutPut))]
        [SwaggerResponse(statusCode: 500, description: "Sucesso ao autenticar", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Registrar(RegistroViewModelInput registro)
        {
            var usuario = new Usuario
            {
                Login = registro.Login,
                Senha = registro.Senha,
                Email = registro.Email
            };

            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.Commit();

            return Created("", registro);
        }
    }
}
