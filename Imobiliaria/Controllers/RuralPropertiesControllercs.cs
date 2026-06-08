using Imobiliaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Imobiliaria.Controllers
{
    public class RuralPropertiesControllercs : Controller
    {
        private static List<RuralProperty> _ruralProperties = new List<RuralProperty>();

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
            return View(_ruralProperties);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new RuralProperty);
        }

        [HttpPost]
        public IActionResult Create(RuralProperty property)
        {
            if (property is null) return View(property);
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
        public IActionResult Update(int id, RuralProperty property)
        {
            if (id <= 0) return BadRequest();
            if (property == null) return NotFound();

            if(id != property.Id) return BadRequest();

            _ruralProperties.Update(property);

            return RedirectToAction(nameof(Index));
        }
    }
}
