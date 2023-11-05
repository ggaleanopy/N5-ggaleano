using DataAccessEF.TypeRepository;
using Domain.Interfaces;

namespace DataAccessEF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private N5nowDbContext context;
        public UnitOfWork(N5nowDbContext context)
        {
            this.context = context;
            Permission = new PermissionRepository(this.context);
            PermissionType = new PermissionTypeRepository(this.context);
        }

        public IPermissionRepository Permission { get; private set; }
        public IPermissionTypeRepository PermissionType { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
