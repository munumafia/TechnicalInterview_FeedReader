using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalInterview_FeedReader.Data.Entities;

namespace TechnicalInterview_FeedReader.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class, IEntity
    {
        private readonly FeedContext _feedContext;
        protected FeedContext FeedContext { get { return _feedContext; } }

        public Repository()
        {
            _feedContext = new FeedContext();
        }

        public TEntity FindById(int id)
        {
            return _feedContext.Set<TEntity>().Find(id);
        }

        public void SaveChanges()
        {
            _feedContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _feedContext.Set<TEntity>().Remove(entity);
        }

        public void Add(TEntity entity)
        {
            _feedContext.Set<TEntity>().Add(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _feedContext.Set<TEntity>();
        }
    }
}
