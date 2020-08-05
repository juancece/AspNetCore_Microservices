using System.Collections.Generic;
using MS.AFORO255.Security.Model;

namespace MS.AFORO255.Security.Repository
{
    public interface IAccessRepository
    {
        IEnumerable<Access> GetAll();
    }
}