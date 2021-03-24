using EfCoreCrud.Entities.Models;
using EfCoreCrud.Services.CategoryService;
using EfCoreCrud.Services.PictureService;
using EfCoreCrud.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreCrud.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IPictureService _pictureService;
        public ProductController(IProductService productService, ICategoryService categoryService, IPictureService pictureService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _pictureService = pictureService;
        }
        public IActionResult Index()
        {
            return View(_productService.GetAllIncluding().OrderByDescending(i => i.CreatedDate).ToList());
        }
        public IActionResult Detail(int id)
        {
            return View(_productService.GetById(id));
        }
        public IActionResult Category(int? id)
        {
            return View(_productService.GetAllIncluding().Where(i => i.CategoryId == id).OrderByDescending(i => i.CreatedDate).ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAllIncluding().Where(i => i.IsConfirm == true).OrderByDescending(i => i.Products.Count()).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product model)
        {
            var result = _productService.Create(model);
            if (result.Success)
            {
                TempData["message"] = result.Message;
                return RedirectToAction(nameof(Create));
            }
            else
            {
                TempData["message"] = result.Message;
                return RedirectToAction(nameof(Create));
            }
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _categoryService.GetAllIncluding().Where(i => i.IsConfirm == true).OrderByDescending(i => i.Products.Count()).ToList();
            var updateProduct = _productService.GetById(id);
            if (updateProduct != null)
            {
                return View(updateProduct);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product model)
        {
            var result = _productService.Update(model);
            if (result.Success)
            {
                TempData["message"] = result.Message;
                return RedirectToAction(nameof(Edit));
            }
            else
            {
                TempData["message"] = result.Message;
                return RedirectToAction(nameof(Edit));
            }
        }

        public IActionResult CreatePhoto(int? id)
        {
            ViewBag.ProductId = _productService.GetById(id);
            Picture model = new Picture
            {
                ProductId = id,
            };
            return View("CreatePhoto", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePhoto(int? productId, string title, IFormFile image)
        {
            var model = new Picture
            {
                ProductId = productId,
                Title = title
            };
            if (image != null && image.Length > 0)
            {
                var path = Path.GetExtension(image.FileName);
                var photoName = Guid.NewGuid() + path;
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/product/" + photoName);
                var stream = new FileStream(upload, FileMode.Create);
                image.CopyTo(stream);
                model.ImageUrl = photoName;
            }
            var result = _pictureService.Create(model);
            if (result.Success)
            {
                TempData["message"] = result.Message;
                return RedirectToAction(nameof(CreatePhoto));
            }
            else
            {
                TempData["message"] = result.Message;
                return RedirectToAction(nameof(CreatePhoto));
            }
        }
        public IActionResult MultiplePhotoCreate(int? id)
        {
            ViewBag.ProductId = _productService.GetById(id);
            Picture model = new Picture
            {
                ProductId = id,
            };
            return View("MultiplePhotoCreate", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MultiplePhotoCreate(int? productId, string title, IEnumerable<IFormFile> images)
        {

            foreach (var image in images)
            {
                var model = new Picture
                {
                    ProductId = productId,
                    Title = title
                };
                var path = Path.GetExtension(image.FileName);
                var photoName = Guid.NewGuid() + path;
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/product/" + photoName);
                var stream = new FileStream(upload, FileMode.Create);
                image.CopyTo(stream);
                model.ImageUrl = photoName;

                _pictureService.Create(model);
            }
            return RedirectToAction(nameof(MultiplePhotoCreate));
        }
        public ActionResult Active(int id)
        {
            var result = _productService.SetActive(id);
            if (result.Success)
            {
                TempData["message"] = result.Message;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["message"] = result.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult DeActive(int id)
        {
            var result = _productService.SetDeActive(id);
            if (result.Success)
            {
                TempData["message"] = result.Message;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["message"] = result.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Delete(int id)
        {
            var deleteProduct = _productService.GetById(id);
            if (deleteProduct != null)
            {
                var result = _productService.Delete(deleteProduct);
                if (result.Success)
                {
                    TempData["message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
