using EfCoreCrud.Business.Abstract;
using EfCoreCrud.Core.Business.EntityFramework;
using EfCoreCrud.DataAccess.EntityFramework;
using EfCoreCrud.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCrud.Business.Concrete
{
    public class CategoryManager : EfBaseRepository<Category, ApplicationDbContext>, ICategoryRepository
    {
        public List<Category> GetAllIncluding()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<Category>().Include("Products").ToList();
            }
        }

        public void SetActive(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var active = context.Set<Category>().Where(i => i.Id == id).FirstOrDefault();
                active.IsConfirm = true;
                context.SaveChanges();
            }
        }

        public void SetDeActive(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var deActive = context.Set<Category>().Where(i => i.Id == id).FirstOrDefault();
                deActive.IsConfirm = false;
                context.SaveChanges();
            }
        }
    }
}
