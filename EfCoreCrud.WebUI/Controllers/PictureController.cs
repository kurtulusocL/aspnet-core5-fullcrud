using EfCoreCrud.Entities.Models;
using EfCoreCrud.Services.PictureService;
using EfCoreCrud.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;


namespace EfCoreCrud.WebUI.Controllers
{
    public class PictureController : Controller
    {
        private readonly IPictureService _pictureService;
        private readonly IProductService _productService;
        public PictureController(IPictureService pictureService, IProductService productService)
        {
            _pictureService = pictureService;
            _productService = productService;
        }
        public IActionResult Index(int page = 1)
        {
            return View(_pictureService.GetAllIncluding().OrderByDescending(i => i.CreatedDate).ToPagedList(page, 4));
        }
        public IActionResult Product(int? id)
        {
            return View(_pictureService.GetAllIncluding().Where(i => i.ProductId == id).OrderByDescending(i => i.CreatedDate).ToList());
        }
        public ActionResult Edit(int? id)
        {
            var updatePhoto = _pictureService.GetAllIncluding().Where(i => i.ProductId == id).FirstOrDefault(i => i.Id == id);
           
            if (updatePhoto != null)
            {
                return View(updatePhoto);
            }
            return RedirectToAction(nameof(Edit));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Picture model, IFormFile image)
        {            
            if (image != null && image.Length > 0)
            {
                var path = Path.GetExtension(image.FileName);
                var photoName = Guid.NewGuid() + path;
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/product/" + photoName);
                var stream = new FileStream(upload, FileMode.Create);
                image.CopyTo(stream);
                model.ImageUrl = photoName;
            }
            _pictureService.Update(model);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult MultiplePhotoEdit(int? id)
        {
            var updatePhoto = _pictureService.GetAllIncluding().Where(i => i.ProductId == id).FirstOrDefault(i => i.Id == id);

            if (updatePhoto != null)
            {
                return View(updatePhoto);
            }
            return RedirectToAction(nameof(Edit));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MultiplePhotoEdit(Picture model, IEnumerable<IFormFile> images)
        {
            foreach (var image in images)
            {
                var path = Path.GetExtension(image.FileName);
                var photoName = Guid.NewGuid() + path;
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/product/" + photoName);
                var stream = new FileStream(upload, FileMode.Create);
                image.CopyTo(stream);
                model.ImageUrl = photoName;

                _pictureService.Create(model);
            }
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Active(int id)
        {
            _pictureService.SetActive(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeActive(int id)
        {
            _pictureService.SetDeActive(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var deletePicture = _pictureService.GetById(id);
            if (deletePicture != null)
            {
                _pictureService.Delete(deletePicture);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
