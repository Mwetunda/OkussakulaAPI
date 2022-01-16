using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Okussakula.Model;
using Okussakula.Model.Data;
using Okussakula.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Okussakula.Service.Services
{
    public class ConsultServices : IConsult
    {
        private DataContext _context;
        private readonly ILogger<ConsultServices> _logger;

        public ConsultServices(DataContext context, ILogger<ConsultServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        
        public Response Insert(Consult entity)
        {
            var resposta = new Response();

            try
            {
                
                entity.State = true;
                entity.DataInsert = DateTime.Now;
                entity.DataUpdate = DateTime.Now;

                _context.Consults.Add(entity);
                _context.SaveChanges();

                return resposta.Good("Consulta marcada com sucesso", entity);

            }
            catch (Exception e)
            {
                return resposta.Bad("Erro ao marcar consulta "+e);
            }
        }

        public Response List(long instituitionId)
        {
            var resposta = new Response();

            try
            {
                var lista = _context.Consults
                    .Include(x => x.User)
                    .Include(x => x.ConsultHorario)
                    .ThenInclude(x => x.CronogramConsult)
                    .ThenInclude(x => x.InstituitionSpeciality)
                    .ThenInclude(x => x.Speciality)
                    .AsNoTracking()
                    .Where(x => x.ConsultHorario.CronogramConsult.InstituitionSpeciality.InstituitionId == instituitionId)
                    .OrderBy(x => x.DataInsert);

                return resposta.Good("Lista de Consultas", lista);
            }
            catch (Exception e)
            {
                return resposta.Bad("Erro ao gerar lista " + e);
            }
        }

        public Response ListBySpeciality(long instituitionId, long specialityId)
        {
            var resposta = new Response();

            try
            {
                var lista = _context.Consults
                    .Include(x => x.User)
                    .Include(x => x.ConsultHorario)
                    .ThenInclude(x => x.CronogramConsult)
                    .ThenInclude(x => x.InstituitionSpeciality)
                    .AsNoTracking()
                    .Where(x => x.ConsultHorario.CronogramConsult.InstituitionSpeciality.InstituitionId == instituitionId && x.ConsultHorario.CronogramConsult.InstituitionSpeciality.SpecialityId == specialityId)
                    .OrderBy(x => x.DataInsert);

                return resposta.Good("Lista de Consultas", lista);
            }
            catch (Exception e)
            {
                return resposta.Bad("Erro ao gerar lista " + e);
            }
        }

        public Response ListByUser(long userId)
        {
            var resposta = new Response();

            try
            {
                var lista = _context.Consults
                    .Include(x => x.ConsultHorario)
                    .ThenInclude(x => x.CronogramConsult)
                    .ThenInclude(x => x.InstituitionSpeciality)
                    .ThenInclude(x => x.Speciality)
                    .AsNoTracking()
                    .Where(x => x.UserId == userId)
                    .OrderBy(x => x.DataInsert);

                return resposta.Good("Lista de Consultas", lista);
            }
            catch (Exception e)
            {
                return resposta.Bad("Erro ao gerar lista " + e);
            }
        }
    }
}
