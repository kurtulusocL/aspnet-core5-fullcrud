using EfCoreCrud.Core.Utilities.Results;
using EfCoreCrud.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCrud.Services.PictureService
{
    public interface IPictureService
    {
        List<Picture> GetAllIncluding();
        Picture GetById(int? id);
        IResult Create(Picture model);
        void Update(Picture model);
        void Delete(Picture model);
        void SetActive(int id);
        void SetDeActive(int id);
    }
}
