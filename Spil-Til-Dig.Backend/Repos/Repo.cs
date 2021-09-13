using Microsoft.EntityFrameworkCore;
using Spil_Til_Dig.Backend.Database;
using Spil_Til_Dig.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Backend.Repos
{
    public abstract class Repo<Entity, IdType> : IRepo<Entity, IdType> where Entity : BaseEntity<IdType>
    {
        protected readonly DatabaseContext _context;

        protected Repo(DatabaseContext context)
        {
            _context = context;
        }

        public virtual IQueryable<Entity> GetAll()
        {
            return _context.Set<Entity>();
        }

        public virtual Entity Get(IdType Id)
        {
            return _context.Set<Entity>().Find(Id);
        }

        public virtual async Task<Entity> GetAsync(IdType Id)
        {
            return await _context.Set<Entity>().FindAsync(Id);
        }

        public IEnumerable<Entity> FindAll(Expression<Func<Entity, bool>> predicate)
        {
            return _context.Set<Entity>().Where(predicate);
        }
        public async Task<IEnumerable<Entity>> FindAllAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _context.Set<Entity>().Where(predicate).ToListAsync();
        }
        public void Add(Entity entity)
        {
            _context.Set<Entity>().Add(entity);
        }

        public virtual async Task AddAsync(Entity entity)
        {
            await _context.Set<Entity>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<Entity> entitis)
        {
            _context.Set<Entity>().AddRange(entitis);
        }

        public async Task AddRangeAsync(IEnumerable<Entity> entitis)
        {
            await _context.Set<Entity>().AddRangeAsync(entitis);
        }

        public virtual void Remove(Entity entity)
        {
            _context.Remove<Entity>(entity);
        }

        public void RemoveRange(IEnumerable<Entity> entitis)
        {
            //Go to every entity and remove them
            foreach (var entity in entitis)
                Remove(entity);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public virtual void Update(Entity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _context.Set<Entity>().Update(entity);
        }
        public async Task<bool> AnyAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _context.Set<Entity>().AnyAsync(predicate);
        }

        public bool Any(Expression<Func<Entity, bool>> predicate)
        {
            return _context.Set<Entity>().Any(predicate);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<Entity>().CountAsync();
        }

        public Entity Find(Expression<Func<Entity, bool>> predicate)
        {
            return  _context.Set<Entity>().FirstOrDefault(predicate);
        }

        public async Task<Entity> FindAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _context.Set<Entity>().FirstOrDefaultAsync(predicate);
        }
    }
}
