using Imobiliaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Repository;
using Model;
using Imobiliaria.Repository;


namespace Imobiliaria.Controllers
{
    public class ResidentialPropertiesController : Controller
    {
        private ResidentialPropertyRepository _residentialProperties;

        public ResidentialPropertiesController()
        {
            _residentialProperties = new ResidentialPropertyRepository();
        }

        public IActionResult Index(string search)
        {
            List<ResidentialProperty> properties = [];

            if (!string.IsNullOrEmpty(search))
            {
                properties = _residentialProperties.GetByName(search);
            }
            else
            {
                properties = _residentialProperties.GetAll();
            }
            return View(properties);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ResidentialProperty());
        }

        [HttpPost]
        public IActionResult Create(ResidentialProperty property)
        {
            if (property is null) return View(property);
            _residentialProperties.Create(property);


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var property = _residentialProperties.GetById(id);
            if (property is null) return NotFound();
            return View(property);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            if (id <= 0) return BadRequest();
            var property = _residentialProperties.GetById(id);

            _residentialProperties.Delete(property);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id <= 0) return BadRequest();
            var property = _residentialProperties.GetById(id);

            if (property == null) return NotFound();
            return View(property);
        }

        [HttpPost]
        public IActionResult Update(int id, ResidentialProperty property)
        {
            if (id <= 0) return BadRequest();
            if (property == null) return NotFound();

            if (id != property.Id) return BadRequest();

            _residentialProperties.Update(property);

            return RedirectToAction(nameof(Index));
        }

    }
}
