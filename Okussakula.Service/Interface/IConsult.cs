using Okussakula.Model;
using Okussakula.Model.Data;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Okussakula.Service.Interface
{
    public interface IConsult
    {
        Response Insert(Consult dto);
        Response List(long instituitionId);
        Response ListBySpeciality(long instituitionId, long specialityId);
        Response ListByUser(long userId);
        //Response GetByID(Guid id);
        //Response Update(FuncionarioDTOApiUpdate dto);
        //Response Delete(Guid id);
        //Response RecoveryPassword(string chave, string newPassword);
        //Response RequestRecoveryPassword(string email);
        //Response UpdatePassword(Guid id, string actualPassword, string newPassword);
        //Response ReactivarAdm(Guid id);
    }
}
