using Okussakula.Model;
using Okussakula.Model.Data;
using System.Collections.Generic;

namespace Okussakula.Service.Interface
{
    public interface IInstituition
    {
        Response Insert(Instituition dto);

        Response InsertSpeciality(List<InstituitionSpeciality> dto);

        Response InsertExam(List<InstituitionExam> dto);
        Response List(long id);
        Response ListSpeciality(long id);
        Response ListExam(long id);

    }
}
