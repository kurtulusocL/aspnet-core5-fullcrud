using EfCoreCrud.Core.Business;
using EfCoreCrud.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCrud.Business.Abstract
{
    public interface IPictureRepository : IEntityRepository<Picture>
    {
        List<Picture> GetAllIncluding();
        void SetActive(int id);
        void SetDeActive(int id);
    }
}
