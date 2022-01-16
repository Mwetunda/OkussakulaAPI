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
    public class InstituitionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInstituition _repository;

        public InstituitionController(IInstituition repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Registar")]
        public ActionResult Insert(InstituitionCreatDTO dto)
        {

            try
            {
                var entityMaper = _mapper.Map<Instituition>(dto);

                var entity = _repository.Insert(entityMaper);

                if (entity.Exito)
                {
                    entity.Objeto = _mapper.Map<InstituitionListDTO>(entity.Objeto);

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
                retorno.Mensagem = "Erro ao registar instituição " + e;

                return BadRequest(retorno);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("InsertSpeciality")]
        public ActionResult InsertSpeciality(List<InstituitionSpecialityCreatDTO> dto)
        {

            try
            {
                var entityMaper = _mapper.Map<List<InstituitionSpeciality>>(dto);

                var entity = _repository.InsertSpeciality(entityMaper);

                if (entity.Exito)
                {
                    entity.Objeto = _mapper.Map<List<InstituitionSpecialityDTO>>(entity.Objeto);

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
                retorno.Mensagem = "Erro ao adicionar especialidades " + e;

                return BadRequest(retorno);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("InsertExam")]
        public ActionResult InsertExam(List<InstituitionExamCreatDTO> dto)
        {

            try
            {
                var entityMaper = _mapper.Map<List<InstituitionExam>>(dto);

                var entity = _repository.InsertExam(entityMaper);

                if (entity.Exito)
                {
                    entity.Objeto = _mapper.Map<List<InstituitionExamDTO>>(entity.Objeto);

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
                retorno.Mensagem = "Erro ao adicionar exames " + e;

                return BadRequest(retorno);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("ListBySpeciality")]
        public ActionResult ListBySpeciality(long id)
        {

            try
            {

                var entity = _repository.List(id);

                if (entity.Exito)
                {
                    entity.Objeto = _mapper.Map<List<InstituitionListDTO>>(entity.Objeto);

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
        [Route("ListSpeciality")]
        public ActionResult ListSpeciality(long id)
        {

            try
            {

                var entity = _repository.ListSpeciality(id);

                if (entity.Exito)
                {
                    entity.Objeto = _mapper.Map<List<InstituitionSpecialityDTO>>(entity.Objeto);

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
