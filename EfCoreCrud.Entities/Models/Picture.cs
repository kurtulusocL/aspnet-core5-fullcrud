using EfCoreCrud.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCrud.Entities.Models
{
    public class Picture : BaseHome
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
