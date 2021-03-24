using EfCoreCrud.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCrud.Entities.Models
{
    public class Product : BaseHome
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
