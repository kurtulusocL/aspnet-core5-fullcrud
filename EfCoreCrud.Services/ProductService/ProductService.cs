using EfCoreCrud.Business.Abstract;
using EfCoreCrud.Business.Constants;
using EfCoreCrud.Business.ValidationRules.FluentValidation;
using EfCoreCrud.Core.Aspect;
using EfCoreCrud.Core.Utilities.Results;
using EfCoreCrud.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCrud.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Create(Product model)
        {
            _productRepository.Create(model);
            return new SuccessResult(Messages.ProductAdded);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Delete(Product model)
        {
            _productRepository.Delete(model);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public /*IDataResult<List<Product>>*/ List<Product> GetAllIncluding() //you can do that way if you want too
        {
            //return new SuccessDataResult<List<Product>>(_productRepository.GetAllIncluding(), Messages.ProductsListed);
            return _productRepository.GetAllIncluding();
        }

        public /*IDataResult<Product>*/ Product GetById(int? id) //you can do that way if you want too
        {
            //return new SuccessDataResult<Product>(_productRepository.GetById(id), Messages.ProductsListedById);
            return _productRepository.GetById(id);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult SetActive(int id)
        {
            _productRepository.SetActive(id);
            return new SuccessResult(Messages.ProductActived);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult SetDeActive(int id)
        {
            _productRepository.SetDeActive(id);
            return new SuccessResult(Messages.ProductSuspended);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product model)
        {
            model.UpdatedDate = DateTime.Now.ToLocalTime();
            _productRepository.Update(model);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
