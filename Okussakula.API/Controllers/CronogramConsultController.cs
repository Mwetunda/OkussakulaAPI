
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
    public class CronogramConsultController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICronogramConsult _repository;
        public CronogramConsultController(ICronogramConsult repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Registar")]
        public ActionResult Insert(ConsultCronogramCreatDTO dto)
        {

            try
            {
                var entityMaper = _mapper.Map<CronogramConsult>(dto);

                var entity = _repository.Insert(entityMaper, dto.Intervalo);

                if (entity.Exito)
                {
                    entity.Objeto = _mapper.Map<ConsultCronogramDTO>(entity.Objeto);

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
                retorno.Mensagem = "Erro ao criar cronograma " + e;

                return BadRequest(retorno);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("List")]
        public ActionResult List(long instituitionId)
        {

            try
            {

                var entity = _repository.List(instituitionId);

                if (entity.Exito)
                {
                    entity.Objeto = _mapper.Map<List<ConsultCronogramDTO>>(entity.Objeto);

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
                retorno.Mensagem = "Erro ao listar especialidades " + e;

                return BadRequest(retorno);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("ListBySpeciality")]
        public ActionResult ListBySpeciality(long instituitionId, long specialityId)
        {

            try
            {

                var entity = _repository.ListBySpeciality(instituitionId, specialityId);

                if (entity.Exito)
                {
                    entity.Objeto = _mapper.Map<List<ConsultCronogramDTO>>(entity.Objeto);

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
                retorno.Mensagem = "Erro ao listar especialidades " + e;

                return BadRequest(retorno);
            }
        }
    }
}
