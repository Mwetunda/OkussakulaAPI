
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Okussakula.Model;
using Okussakula.Model.Data;
using Okussakula.Model.DTO;
using Okussakula.Service.Interface;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Okussakula.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConsult _repository;

        public ConsultController(IConsult repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Registar")]
        public ActionResult Insert(ConsultCreatDTO dto)
        {

            try
            {
                var entityMaper = _mapper.Map<Consult>(dto);

                var entity = _repository.Insert(entityMaper);

                if (entity.Exito)
                {
                    entity.Objeto = _mapper.Map<ConsultListDTO>(entity.Objeto);

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
                retorno.Mensagem = "Erro ao marcar consulta " + e;

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
                    entity.Objeto = _mapper.Map<List<ConsultListConsultsDTO>>(entity.Objeto);

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
                retorno.Mensagem = "Erro ao listar consultas " + e;

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
                    entity.Objeto = _mapper.Map<List<ConsultListConsultsDTO>>(entity.Objeto);

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
                retorno.Mensagem = "Erro ao listar consultas " + e;

                return BadRequest(retorno);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("ListByUser")]
        public ActionResult ListByUser(long userId)
        {

            try
            {

                var entity = _repository.ListByUser(userId);

                if (entity.Exito)
                {
                    entity.Objeto = _mapper.Map<List<ConsultListConsultsDTO>>(entity.Objeto);

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
                retorno.Mensagem = "Erro ao listar consultas " + e;

                return BadRequest(retorno);
            }
        }
    }
}
