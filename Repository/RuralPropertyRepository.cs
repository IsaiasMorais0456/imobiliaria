using System.Xml.Linq;
using Imobiliaria.Models;
using Model;
using Repository;
using Repository.VirtualDatabase;

namespace Imobiliaria.Repository
{
    public class RuralPropertyRepository : BaseRepository<RuralProperty>
    {
        
        public void Create(RuralProperty property)
        {
            property.Id = GetNextId(property);
            MyData.RuralProperties.Add(property);
        }

        public void Delete(RuralProperty property)
        {
            MyData.RuralProperties.Remove(property);
        }

        public void Update(RuralProperty property)
        {
            var _RuralProperty = GetById(property.Id);

            _RuralProperty.Title = property.Title;
            _RuralProperty.Price = property.Price;
            _RuralProperty.Hectares = property.Hectares;
            _RuralProperty.HasWaterSource = property.HasWaterSource;
            _RuralProperty.Location = property.Location;
            _RuralProperty.Description = property.Description;
            _RuralProperty.BusinessType = property.BusinessType;
            _RuralProperty.Category = property.Category;

        }

        public RuralProperty GetById(int id)
        {
            var RuralProperty = MyData.RuralProperties.FirstOrDefault(x => x.Id == id);
            if (RuralProperty is null) return null!;
            return RuralProperty;
        }

        public List<RuralProperty> GetByName(string name)
        {
            List<RuralProperty> RuralProperties = [];

            foreach (var c in MyData.RuralProperties)
            {
                /*
                if (c.FirstName.ToLower().Contains(name.ToLower()) ||
                   c.LastName.ToLower().Contains(name.ToLower()))
                {
                    RuralPropertys.Add(c);
                }
                */

                if (c.Title.ToLower().Contains(name.ToLower()))
                    RuralProperties.Add(c);
            }

            return RuralProperties;
        }

        public List<RuralProperty> GetAll()
        {
            return MyData.RuralProperties;
        }
    }
}
