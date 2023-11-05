using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPermissionRepository : IGenericRepository<Permission>
    {
        public List <Permission> GetPermissions();
        public Permission AddPermission(Permission permission);
        public Permission UpdatePermission(Permission permission);
        public Permission GetPermissionById(int id);

    }
}
