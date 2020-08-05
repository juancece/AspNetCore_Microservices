using System.Collections.Generic;
using System.Linq;
using MS.AFORO255.Security.Model;
using MS.AFORO255.Security.Repository;

namespace MS.AFORO255.Security.Service
{
    public class AccessService : IAccessService
    {
        private readonly IAccessRepository _accessRepository;

        public AccessService(IAccessRepository accessRepository)
        {
            _accessRepository = accessRepository;
        }
        public IEnumerable<Access> GetAll()
        {
            return _accessRepository.GetAll();
        }

        public bool Validate(string userName, string password)
        {
            var list = _accessRepository.GetAll();
            var access = list.FirstOrDefault(x => x.Username == userName && x.Password == password);
            return access != null;
        }
    }
}