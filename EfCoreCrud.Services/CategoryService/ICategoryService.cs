using EfCoreCrud.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCrud.Services.CategoryService
{
    public interface ICategoryService
    {
        List<Category> GetAllIncluding();
        Category GetById(int? id);
        void Create(Category model);
        void Update(Category model);
        void Delete(Category model);
        void SetActive(int id);
        void SetDeActive(int id);
    }
}
