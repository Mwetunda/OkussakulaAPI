using Okussakula.Model;
using Okussakula.Model.Data;

namespace Okussakula.Service.Interface
{
    public interface IUser
    {
        Response Insert(User dto);
        Response Login(User entity, string secret);
        //Response List(int page, int take, string filtro = null);
        Response GetByID(long id);
    }
}
