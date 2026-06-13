using Imobiliaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Repository;
using Model;
using Imobiliaria.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Imobiliaria.Controllers
{
    public class RuralPropertiesController : Controller
    {
        private RuralPropertyRepository _ruralProperties;
        private readonly IWebHostEnvironment _webHostEnvironment; // serviço necessário para encontrar a pasta do wwwroot

        public RuralPropertiesController(IWebHostEnvironment webHostEnvironment) 
        {
            _ruralProperties = new RuralPropertyRepository();
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(string search)
        {
            List<RuralProperty> properties = [];

            if(!string.IsNullOrEmpty(search))
            {
                properties = _ruralProperties.GetByName(search);
            }
            else
            {
                properties = _ruralProperties.GetAll();
            }
            return View(properties);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new RuralProperty());
        }

        [HttpPost]
        public IActionResult Create(RuralProperty property, IFormFile imageFile)
        {
            if (property is null) return View(property); //verificação 

            #region tratamento da imagem

            if (imageFile != null && imageFile.Length > 0)
            {
                string UploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "images", "ruralProperty");

                if (!System.IO.Directory.Exists(UploadsFolder))
                {
                    System.IO.Directory.CreateDirectory(UploadsFolder);
                }
                ; 

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                string filePath = Path.Combine(UploadsFolder, uniqueFileName); // pacote final da imagem

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }

                property.ImageUrl = "/assets/images/ruralProperty/" + uniqueFileName;
            }
            else
            {
                property.ImageUrl = "/assets/images/ruralProperty/default.jpg";
            }

            #endregion


            _ruralProperties.Create(property);


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();
            
            var property = _ruralProperties.GetById(id);
            if (property is null) return NotFound();
            return View(property);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            if (id <= 0) return BadRequest();
            var property = _ruralProperties.GetById(id);

            _ruralProperties.Delete(property);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            if(id <= 0) return BadRequest();
            var property = _ruralProperties.GetById(id);

            if (property == null) return NotFound();
            return View(property);
        }

        [HttpPost]
        public IActionResult Update(int id, RuralProperty property, IFormFile imageFile)
        {
            if (id <= 0) return BadRequest();
            if (property == null) return NotFound();

            if(id != property.Id) return BadRequest();

            if (imageFile != null && imageFile.Length > 0)
            {
                string UploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "images", "ruralProperty");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                string filePath = Path.Combine(UploadsFolder, uniqueFileName); // pacote final da imagem

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }

                property.ImageUrl = "/assets/images/ruralProperty/" + uniqueFileName;
            }
            else
            {
                var oldImage = _ruralProperties.GetById(id);
                property.ImageUrl = oldImage?.ImageUrl;
            }


            _ruralProperties.Update(property);

            return RedirectToAction(nameof(Index));
        }
    }
}
