using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPermissionTypeRepository : IGenericRepository<PermissionType>
    {
        public List<PermissionType> GetPermissionTypes();
        public PermissionType AddPermissionType(PermissionType permissionType);

    }
}
