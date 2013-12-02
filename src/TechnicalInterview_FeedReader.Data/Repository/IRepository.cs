using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalInterview_FeedReader.Data.Entities;

namespace TechnicalInterview_FeedReader.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity FindById(int id);
        void SaveChanges();
        void Delete(TEntity entity);
        void Add(TEntity entity);
        IQueryable<TEntity> GetAll();
    }
}
