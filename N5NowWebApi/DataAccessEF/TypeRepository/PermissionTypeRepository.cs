using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.TypeRepository
{
    class PermissionTypeRepository : GenericRepository<PermissionType>, IPermissionTypeRepository
    {
        private readonly N5nowDbContext _dbContext;
        public PermissionTypeRepository(N5nowDbContext context) : base(context)
        {
            _dbContext= context;
        }

        public List<PermissionType> GetPermissionTypes()
        {
            //return context.PermissionTypes.ToList();
            return GetAll().ToList();
        }
        public PermissionType AddPermissionType(PermissionType permissionType)
        {
            //var result = _dbContext.PermissionTypes.Add(permissionType);
            //_dbContext.SaveChanges();
            //return result.Entity;
            var result = Add(permissionType);
            return result;
        }
    }
}

