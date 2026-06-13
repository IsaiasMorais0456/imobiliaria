using Imobiliaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Repository;
using Model;
using Imobiliaria.Repository;

namespace Imobiliaria.Controllers
{
    public class CommercialPropertiesController : Controller
    {
        private CommercialPropertyRepository _commercialProperties;

        public CommercialPropertiesController()
        {
            _commercialProperties = new CommercialPropertyRepository();
        }

        public IActionResult Index(string search)
        {
            List<CommercialProperty> properties = [];

            if (!string.IsNullOrEmpty(search))
            {
                properties = _commercialProperties.GetByName(search);
            }
            else
            {
                properties = _commercialProperties.GetAll();
            }
            return View(properties);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CommercialProperty());
        }

        [HttpPost]
        public IActionResult Create(CommercialProperty property)
        {
            if (property is null) return View(property);
            _commercialProperties.Create(property);


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var property = _commercialProperties.GetById(id);
            if (property is null) return NotFound();
            return View(property);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            if (id <= 0) return BadRequest();
            var property = _commercialProperties.GetById(id);

            _commercialProperties.Delete(property);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id <= 0) return BadRequest();
            var property = _commercialProperties.GetById(id);

            if (property == null) return NotFound();
            return View(property);
        }

        [HttpPost]
        public IActionResult Update(int id, CommercialProperty property)
        {
            if (id <= 0) return BadRequest();
            if (property == null) return NotFound();

            if (id != property.Id) return BadRequest();

            _commercialProperties.Update(property);

            return RedirectToAction(nameof(Index));
        }
    }
}
