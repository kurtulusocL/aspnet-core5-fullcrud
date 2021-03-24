using EfCoreCrud.Core.Utilities.Results;
using EfCoreCrud.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCrud.Services.ProductService
{
    public interface IProductService
    {
        //IDataResult<List<Product>> GetAllIncluding(); you can do that way if you want too
        //IDataResult<Product> GetById(int? id); you can do that way if you want too
        List<Product> GetAllIncluding();
        Product GetById(int? id);
        IResult Create(Product model);
        IResult Update(Product model);
        IResult Delete(Product model);
        IResult SetActive(int id);
        IResult SetDeActive(int id);
    }
}
