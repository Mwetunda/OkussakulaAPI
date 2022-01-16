using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Okussakula.Model;
using Okussakula.Model.Data;
using Okussakula.Service.Helpers;
using Okussakula.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okussakula.Service.Services
{
    public class UserServices:IUser
    {
        private DataContext _context;
        private readonly ILogger<UserServices> _logger;

        public UserServices(DataContext context, ILogger<UserServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Response Insert(User entity)
        {
            var resposta = new Response();

            try
            {
                entity.Senha = entity.Senha.ToSha512Hash();
                entity.DateInsert = DateTime.Now.Date;
                entity.DateUpdate = DateTime.Now.Date;
                entity.State = true;

                _context.Users.Add(entity);
                _context.SaveChanges();

                return resposta.Good("Conta criada com sucesso", entity);

            }
            catch (Exception e)
            {
                return resposta.Bad("Erro ao criar conta " + e);
            }
        }

        public Response Login(User entity, string secret)
        {
            var res = new Response();

            try
            {
                var admPass = entity.Senha.ToSha512Hash();

                var adm = _context.Users
                    .FirstOrDefault(x => x.Telephone == entity.Telephone && x.Senha == admPass);


                if (adm == null)
                {
                    return res.Bad("Usuário inexistente");
                }
                else if (!adm.State)
                {
                    return res.Bad("Usuário temporariamente sem acesso");
                }
                else
                {
                    var token = JwtToken.GenerateJwtToken(adm, secret, 2);

                    //_context.Update(adm);
                    //_context.SaveChanges();

                    return res.Good("Sucesso", token);
                }
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, "Erro ao efectuar o login");
                return res.Bad("Erro ao efectuar o login");
            }
        }

        public Response GetByID(long id)
        {
            var res = new Response();

            try
            {
                var adm = _context.Users
                    .FirstOrDefault(x => x.UserId == id);

                if (adm != null)
                {
                    return res.Good(adm);
                }

                return res.Bad("Erro ao pesquizar usuário");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao pesquizar usuário");
                return res.Bad("Erro ao pesquizar usuário " + e);
            }
        }
    }
}
