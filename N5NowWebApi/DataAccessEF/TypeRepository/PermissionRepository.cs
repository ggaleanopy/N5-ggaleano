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
    class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        private readonly N5nowDbContext _dbContext;
        public PermissionRepository(N5nowDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public List<Permission> GetPermissions()
        {
            //return context.Permissions.ToList();
            return GetAll().ToList();
        }

        public Permission AddPermission(Permission permission)
        {
            //var result = _dbContext.Permissions.Add(permission);
            //_dbContext.SaveChanges();
            var result = Add(permission);
            return result;
        }

        public Permission UpdatePermission(Permission permission)
        {
            var result = Update(permission);
            return result;
        }

        //public Permission 

        public Permission GetPermissionById(int id)
        {
            //return _dbContext.Permissions.Where(x => x.Id == id).FirstOrDefault();
            return GetById(id);
        }
    }
}

