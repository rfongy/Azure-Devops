using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ModernApiApp.DataAccess {
    public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext> where TDbContext : DbContext, new () {

        private readonly TDbContext _dbContext;
        public TDbContext DbContext { get { return _dbContext; } }
        public UnitOfWork () {
            _dbContext = new TDbContext ();
        }

        public UnitOfWork (TDbContext DbContext) {
            _dbContext = DbContext;
        }

        public Task<int> SaveAsync () {
            return _dbContext.SaveChangesAsync ();
        }
    }
}