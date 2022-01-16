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
    public class ExamController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IExam _repository;

        public ExamController(IExam repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Registar")]
        public ActionResult Insert(ExamCreatDTO dto)
        {

            try
            {
                var entityMaper = _mapper.Map<Exam>(dto);

                var entity = _repository.Insert(entityMaper);

                if (entity.Exito)
                {
                    entity.Objeto = _mapper.Map<ExamDTO>(entity.Objeto);

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
                retorno.Mensagem = "Erro ao registar exame " + e;

                return BadRequest(retorno);
            }
        }
    }
}
