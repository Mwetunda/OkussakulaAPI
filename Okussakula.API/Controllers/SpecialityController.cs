
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Okussakula.Model;
using Okussakula.Model.Data;
using Okussakula.Model.DTO;
using Okussakula.Service.Interface;
using System;
using System.Collections.Generic;

namespace OkussakulaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISpeciality _repository;

        public SpecialityController(ISpeciality repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Registar")]
        public ActionResult Insert(SpecialityCreatDTO dto)
        {

            try
            {
                var entityMaper = _mapper.Map<Speciality>(dto);

                var entity = _repository.Insert(entityMaper);

                if (entity.Exito)
                {
                    entity.Objeto = _mapper.Map<SpecialityDTO>(entity.Objeto);

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
                retorno.Mensagem = "Erro ao registar especialidade " + e;

                return BadRequest(retorno);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Listar")]
        public ActionResult Listar()
        {

            try
            {

                var entity = _repository.List();

                if (entity.Exito)
                {
                    entity.Objeto = _mapper.Map<List<SpecialityDTO>>(entity.Objeto);

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
                retorno.Mensagem = "Erro ao listar especialidade " + e;

                return BadRequest(retorno);
            }
        }
    }
}
