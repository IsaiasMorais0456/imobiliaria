using System.Xml.Linq;
using Model;
using Repository;
using Repository.VirtualDatabase;

namespace Imobiliaria.Repository
{
    public class CommercialPropertyRepository : BaseRepository<CommercialProperty>
    {

        public void Create(CommercialProperty property)
        {
            property.Id = GetNextId(property);
            MyData.CommercialProperties.Add(property);
        }

        public void Delete(CommercialProperty property)
        {
            MyData.CommercialProperties.Remove(property);
        }

        public void Update(CommercialProperty property)
        {
            var _CommercialProperty = GetById(property.Id);

            _CommercialProperty.Title = property.Title;
            _CommercialProperty.Price = property.Price;
            _CommercialProperty.Hectares = property.Hectares;
            _CommercialProperty.HasWaterSource = property.HasWaterSource;
            _CommercialProperty.Location = property.Location;
            _CommercialProperty.Description = property.Description;
            _CommercialProperty.BusinessType = property.BusinessType;
            _CommercialProperty.Category = property.Category;
            _CommercialProperty.RoomSpecification = property.RoomSpecification;

        }

        public CommercialProperty GetById(int id)
        {
            var CommercialProperty = MyData.CommercialProperties.FirstOrDefault(x => x.Id == id);
            if (CommercialProperty is null) return null!;
            return CommercialProperty;
        }

        public List<CommercialProperty> GetByName(string title)
        {
            List<CommercialProperty> CommercialProperties = [];

            foreach (var r in MyData.CommercialProperties)
            {
                if (r.Title.ToLower().Contains(title.ToLower()))
                    CommercialProperties.Add(r);
            }

            return CommercialProperties;
        }

        public List<CommercialProperty> GetAll()
        {
            return MyData.CommercialProperties;
        }
    }
}
