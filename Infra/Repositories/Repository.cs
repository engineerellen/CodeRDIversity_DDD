using Domain;
using Domain.Interfaces;
using Infra.Context;

namespace Infra.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var query = _context.Set<TEntity>();

            if (query.Any())
                return query.ToList();

            return new List<TEntity>();
        }

        public virtual TEntity? GetById(int id)
        {
           var query = _context.Set<TEntity>().Where(e=> e.ID == id);

            if (query.Any())
                return query.FirstOrDefault();

            return null;
        }

        public virtual void Save(TEntity entity)=>
            _context.Set<TEntity>().Add(entity);
    

        public virtual void Update(TEntity entity)=>
            _context.Set<TEntity>().Update(entity);
        
    }
}