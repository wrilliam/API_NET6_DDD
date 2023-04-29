using Domain.Interfaces.Common;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Infrastructure.Repositories.Commons
{
    public class CommonRepository<T> : ICommon<T>, IDisposable where T : class
    {
        #region Attributes

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        private bool disposed;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        #endregion

        #region Constructor

        public CommonRepository()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        #endregion

        #region Behaviors

        public async Task Delete(T entity)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Remove(entity);
                await data.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task Insert(T entity)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                await data.Set<T>().AddAsync(entity);
                await data.SaveChangesAsync();
            }
        }

        public async Task<List<T>> SelectAll()
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task<T> SelectById(int id)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task Update(T entity)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Update(entity);
                await data.SaveChangesAsync();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }

        #endregion
    }
}
