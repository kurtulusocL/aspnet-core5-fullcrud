using EfCoreCrud.Entities.Models;
using EfCoreCrud.Services.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreCrud.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(_categoryService.GetAllIncluding().OrderByDescending(i => i.Products.Count()).ToList());
        }
        public ActionResult Detail(int id)
        {
            return View(_categoryService.GetById(id));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category model, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var path = Path.GetExtension(image.FileName);
                var photoName = Guid.NewGuid() + path;
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/category/" + photoName);
                var stream = new FileStream(upload, FileMode.Create);
                image.CopyTo(stream);
                model.Photo = photoName;
            }

            _categoryService.Create(model);

            return RedirectToAction(nameof(Index));
        }
        public ActionResult Edit(int? id)
        {
            var updateCategory = _categoryService.GetById(id);
            if (updateCategory != null)
            {
                return View(updateCategory);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var path = Path.GetExtension(image.FileName);
                var photoName = Guid.NewGuid() + path;
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/category/" + photoName);
                var stream = new FileStream(upload, FileMode.Create);
                image.CopyTo(stream);
                model.Photo = photoName;
            }
            _categoryService.Update(model);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Active(int id)
        {
            _categoryService.SetActive(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeActive(int id)
        {
            _categoryService.SetDeActive(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var deleteCategory = _categoryService.GetById(id);
            if (deleteCategory != null)
            {
                _categoryService.Delete(deleteCategory);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
