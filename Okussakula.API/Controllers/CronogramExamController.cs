using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Okussakula.Model;
using Okussakula.Model.Data;
using Okussakula.Model.DTO;
using Okussakula.Service.Interface;
using System;

namespace OkussakulaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CronogramExamController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICronogramExam _repository;
        public CronogramExamController(ICronogramExam repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Registar")]
        public ActionResult Insert(CronogramExamCreatDTO dto)
        {

            try
            {
                var entityMaper = _mapper.Map<CronogramExam>(dto);

                var entity = _repository.Insert(entityMaper, dto.Intervalo);

                if (entity.Exito)
                {
                    entity.Objeto = _mapper.Map<CronogramExamDTO>(entity.Objeto);

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
    }
}
