using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Okussakula.Model;
using Okussakula.Model.Data;
using Okussakula.Service.Helpers;
using Okussakula.Service.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace Okussakula.Service.Services
{
    public class AdministradorServices:IAdministrador
    {
        private DataContext _context;
        private readonly ILogger<AdministradorServices> _logger;

        public AdministradorServices(DataContext context, ILogger<AdministradorServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        
        public Response Insert(Administrator entity)
        {
            var resposta = new Response();

            try
            {
                entity.Senha = entity.Senha.ToSha512Hash();
                entity.DateInsert = DateTime.Now.Date;
                entity.DateUpdate = DateTime.Now.Date;
                entity.State = true;

                _context.Administrators.Add(entity);
                _context.SaveChanges();

                return resposta.Good("Administrador registado com sucesso", entity);

            }
            catch (Exception e)
            {
                return resposta.Bad("Erro ao registar administrador "+e);
            }
        }

        public Response Login(Administrator entity, string secret)
        {
            var res = new Response();

            try
            {
                var admPass = entity.Senha.ToSha512Hash();

                var adm = _context.Administrators
                    .FirstOrDefault(x => x.Telephone == entity.Telephone && x.Senha == admPass);


                if (adm == null)
                    return res.Bad("Usuário inexistente");

                if (!adm.State)
                    return res.Bad("Usuário temporariamente sem acesso");

                

                var token = JwtToken.GenerateJwtToken(adm, secret,1);

                //_context.Update(adm);
                //_context.SaveChanges();

                return res.Good("Sucesso", token);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, "Erro ao efectuar o login");
                return res.Bad("Erro ao efectuar login "+e);
            }
        }

        public Response GetByID(long id)
        {
            var res = new Response();

            try
            {
                var adm = _context.Administrators
                    .Include(x => x.Instituition)
                    .FirstOrDefault(x => x.AdministratorId == id);

                if (adm != null)
                {
                    return res.Good(adm);
                }

                return res.Bad("Erro ao pesquizar administrador");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao pesquizar administrador");
                return res.Bad("Erro ao pesquizar administrador " + e);
            }
        }
    }
}
