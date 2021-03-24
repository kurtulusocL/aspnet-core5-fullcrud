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

namespace EfCoreCrud.Services.PictureService
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _pictureRepository;
        public PictureService(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }

        [ValidationAspect(typeof(PictureValidator))]
        public IResult Create(Picture model)
        {
            _pictureRepository.Create(model);
            return new SuccessResult(Messages.ProductPhotosAdded);
        }

        public void Delete(Picture model)
        {
            _pictureRepository.Delete(model);
        }

        public List<Picture> GetAllIncluding()
        {
            return _pictureRepository.GetAllIncluding();
        }

        public Picture GetById(int? id)
        {
            return _pictureRepository.GetById(id);
        }

        public void SetActive(int id)
        {
            _pictureRepository.SetActive(id);
        }

        public void SetDeActive(int id)
        {
            _pictureRepository.SetDeActive(id);
        }

        public void Update(Picture model)
        {
            model.UpdatedDate = DateTime.Now.ToLocalTime();
            _pictureRepository.Update(model);
        }
    }
}
