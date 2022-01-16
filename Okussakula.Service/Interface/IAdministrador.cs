using Okussakula.Model;
using Okussakula.Model.Data;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Okussakula.Service.Interface
{
    public interface IAdministrador
    {
        Response Insert(Administrator entity);
        //Response List(int page, int take, string filtro = null);
        Response GetByID(long id);
        Response Login(Administrator entity, string secret);
        //Response Update(FuncionarioDTOApiUpdate dto);
        //Response Delete(Guid id);
        //Response RecoveryPassword(string chave, string newPassword);
        //Response RequestRecoveryPassword(string email);
        //Response UpdatePassword(Guid id, string actualPassword, string newPassword);
        //Response ReactivarAdm(Guid id);
    }
}
