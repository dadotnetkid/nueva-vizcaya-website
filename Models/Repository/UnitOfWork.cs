using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Models.Repository
{
    public partial class UnitOfWork : IDisposable
    {
        public DbContext context;

        public UnitOfWork()
        {
            context = ModelDb.Create();//(/*DataSource.ConnectionString ?? context.Database.Connection.ConnectionString*/);
        }

        public UnitOfWork(DbContext dbContext)
        {
            this.context = dbContext;
        }
        public UnitOfWork(UnitOfWorkSettings settings)
        {

        }

        private GenericRepository<Posts> _PostsRepo;
        public GenericRepository<Posts> PostsRepo
        {
            get
            {
                if (this._PostsRepo == null)
                    this._PostsRepo = new GenericRepository<Posts>(context);
                return _PostsRepo;
            }
            set { _PostsRepo = value; }
        }
        

        public UnitOfWork(bool lazyLoadingEnabled, bool proxyCreationEnabled)
        {
            context = ModelDb.Create(DataSource.ConnectionString);//(/*DataSource.ConnectionString ?? context.Database.Connection.ConnectionString*/);
            this.context.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
            this.context.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }

        

        



        public void Save()
        {
            context.SaveChanges();

        }


        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
        private bool disposed = false;


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }

    public class UnitOfWorkSettings
    {
        private bool _proxyCreationEnabled;
        private bool _lazyLoading;

        public bool LazyLoading
        {
            get
            {
                if (_lazyLoading == null)
                    _lazyLoading = true;
                return _lazyLoading;
            }
            set => _lazyLoading = value;
        }

        public bool AsNoTracking { get; set; }

        public bool ProxyCreationEnabled
        {
            get
            {
                if (_proxyCreationEnabled == null)
                    _proxyCreationEnabled = true;
                return _proxyCreationEnabled;
            }
            set => _proxyCreationEnabled = value;
        }
    }
}