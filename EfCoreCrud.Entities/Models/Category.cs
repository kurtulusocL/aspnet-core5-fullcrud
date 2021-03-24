using EfCoreCrud.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCrud.Entities.Models
{
    public class Category : BaseHome
    {
        public string Name { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
