using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Okussakula.API.Helpers;
using Okussakula.Model;
using Okussakula.Model.Data;
using Okussakula.Model.DTO;
using Okussakula.Service.Interface;
using System;

namespace OkussakulaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUser _repository;
        private readonly IOptions<AppSettings> _appSettings;

        public UserController(IUser repository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _appSettings = appSettings;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Registar")]
        public ActionResult Insert(UserCreatDTO dto)
        {
            try
            {
                var entityMaper = _mapper.Map<User>(dto);

                var entity = _repository.Insert(entityMaper);

                if (entity.Exito)
                {
                    entity.Objeto = _mapper.Map<UserAuxiliarListlDTO>(entity.Objeto);

                    return Ok(entity);
                }
                else
                {
                    return BadRequest(entity);
                }
            }
            catch (Exception e)
            {
                var retorno = new Response();

                retorno.Exito = false;
                retorno.Mensagem = "Erro ao criar conta " + e;

                return BadRequest(retorno);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(UserLoginDTO dto)
        {

            try
            {
                var entityMaper = _mapper.Map<User>(dto);

                var entity = _repository.Login(entityMaper, _appSettings.Value.TokenSecret);

                if (entity.Exito)
                {

                    return Ok(entity);
                }
                else
                {
                    return BadRequest(entity);
                }
            }
            catch (Exception e)
            {
                var retorno = new Response();

                retorno.Exito = false;
                retorno.Mensagem = "Erro ao fazer login " + e;

                return BadRequest(retorno);
            }
        }

        [HttpGet]
        [Route("Perfil")]
        [Authorize]
        public IActionResult GetById()
        {
            try
            {
                var idUser = User.Identity.Name;

                var entity = _repository.GetByID(Convert.ToInt32(idUser));

                if (entity.Exito)
                {
                    entity.Objeto = _mapper.Map<UserPerfilDTO>(entity.Objeto);

                    return Ok(entity);
                }
                else
                {
                    return BadRequest(entity.Mensagem);
                }
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao gerar perfil " + e);
            }
        }
    }
}
