using System.Collections.Generic;
using MS.AFORO255.Security.Model;

namespace MS.AFORO255.Security.Service
{
    public interface IAccessService
    {
        IEnumerable<Access> GetAll();
        bool Validate(string userName, string password);
    }
}