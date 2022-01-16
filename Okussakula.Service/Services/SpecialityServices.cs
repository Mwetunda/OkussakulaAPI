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
    public class SpecialityServices : ISpeciality
    {
        private DataContext _context;
        private readonly ILogger<SpecialityServices> _logger;

        public SpecialityServices(DataContext context, ILogger<SpecialityServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        
        public Response Insert(Speciality entity)
        {
            var resposta = new Response();

            try
            {
                entity.State = true;

                _context.Specialities.Add(entity);
                _context.SaveChanges();

                return resposta.Good("Especialidade registada com sucesso", entity);

            }
            catch (Exception e)
            {
                return resposta.Bad("Erro ao registar especialidade "+e);
            }
        }
        public Response List()
        {
            var resposta = new Response();

            try
            {
                var lista = _context.Specialities
                .AsNoTracking()
                .Where(x=>x.State == true)
                .OrderBy(x => x.Designation);

                return resposta.Good("Lista de especialidades", lista);
            }
            catch(Exception e)
            {
              return  resposta.Bad("Erro ao gerar lista " + e);
            }
        }
    }
}
