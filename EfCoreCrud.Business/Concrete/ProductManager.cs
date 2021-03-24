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
    public class ProductManager : EfBaseRepository<Product, ApplicationDbContext>, IProductRepository
    {
        public List<Product> GetAllIncluding()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<Product>().Include("Category").Include("Pictures").ToList();
            }
        }

        public void SetActive(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var active = context.Set<Product>().Where(i => i.Id == id).FirstOrDefault();
                active.IsConfirm = true;
                context.SaveChanges();
            }
        }

        public void SetDeActive(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var active = context.Set<Product>().Where(i => i.Id == id).FirstOrDefault();
                active.IsConfirm = false;
                context.SaveChanges();
            }
        }
    }
}
