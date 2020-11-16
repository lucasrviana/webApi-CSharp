using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MeuDbContext _context;
        protected readonly DbSet<TEntity> Db;
        protected Repository(MeuDbContext context)
        {
            _context = context;
            Db = _context.Set<TEntity>();
        }

        public virtual async Task<IList<TEntity>> ObterTodos()
        {
            return await Db.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await Db.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await Db.FindAsync(id);
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            Db.Add(entity);
            await SaveChanges();
        }

        public virtual async Task ForcarAtualizacao(TEntity entity)
        {
            Db.Attach(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            Db.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            Db.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
