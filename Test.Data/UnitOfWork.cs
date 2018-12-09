using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Entities;

namespace Test.Data
{
    public class UnitOfWork: IDisposable
    {
        private TestDbContext _context = new TestDbContext();
        private Repository<User> _usersRepository;
        private Repository<Article> _articlesRepository;
        private bool _disposed = false;

        public Repository<User> UsersRepository
        {
            get
            {
                if (_usersRepository == null)                
                    _usersRepository = new Repository<User>(_context);
                
                return _usersRepository;
            }
        }

        public Repository<Article> ArticlesRepository
        {
            get
            {
                if (_articlesRepository == null)
                    _articlesRepository = new Repository<Article>(_context);

                return _articlesRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)                
                    _context.Dispose();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
