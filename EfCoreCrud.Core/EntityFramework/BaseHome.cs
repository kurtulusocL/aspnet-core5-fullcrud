using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCrud.Core.EntityFramework
{
    public class BaseHome : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsConfirm { get; set; }
        public BaseHome()
        {
            CreatedDate = DateTime.Now.ToLocalTime();
            IsConfirm = true;
        }
    }
}
