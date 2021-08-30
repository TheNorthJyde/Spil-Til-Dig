using Spil_Til_Dig.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Backend.Repos
{
    public interface IRepo<Entity, IdType> where Entity : BaseEntity<IdType>
    {
        IQueryable<Entity> GetAll();
        IEnumerable<Entity> FindAll(Expression<Func<Entity, bool>> predicate);
        Task<IEnumerable<Entity>> FindAllAsync(Expression<Func<Entity, bool>> predicate);
        Entity Find(Expression<Func<Entity, bool>> predicate);
        Task<Entity> FindAsync(Expression<Func<Entity, bool>> predicate);
        Entity Get(IdType Id);
        Task<Entity> GetAsync(IdType Id);
        bool Any(Expression<Func<Entity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<Entity, bool>> predicate);
        void Add(Entity entity);
        Task AddAsync(Entity entity);
        void AddRange(IEnumerable<Entity> entitis);
        Task AddRangeAsync(IEnumerable<Entity> entitis);
        void Remove(Entity entity);
        void RemoveRange(IEnumerable<Entity> entitis);
        void Update(Entity entity);
        int Save();
        Task<int> SaveAsync();
        Task<int> CountAsync();
    }
}
