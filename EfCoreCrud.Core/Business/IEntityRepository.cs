using EfCoreCrud.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCrud.Core.Business
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll();
        T GetById(int? id);
        void Create(T model);
        void Update(T model);       
        void Delete(T model);
    }
}
