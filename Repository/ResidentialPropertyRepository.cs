using System.Xml.Linq;
using Model;
using Repository;
using Repository.VirtualDatabase;
namespace Repository
{
    public class ResidentialPropertyRepository : BaseRepository<ResidentialProperty>
    {
        public void Create(ResidentialProperty property)
        {
            property.Id = GetNextId(property);
            MyData.ResidentialProperties.Add(property);
        }

        public void Delete(ResidentialProperty property)
        {
            MyData.ResidentialProperties.Remove(property);
        }

        public void Update(ResidentialProperty property)
        {
            var _ResidentialProperty = GetById(property.Id);

            _ResidentialProperty.Title = property.Title;
            _ResidentialProperty.Price = property.Price;
            _ResidentialProperty.Hectares = property.Hectares;
            _ResidentialProperty.HasWaterSource = property.HasWaterSource;
            _ResidentialProperty.Location = property.Location;
            _ResidentialProperty.Description = property.Description;
            _ResidentialProperty.BusinessType = property.BusinessType;
            _ResidentialProperty.Category = property.Category;
            _ResidentialProperty.RoomSpecification = property.RoomSpecification;

        }

        public ResidentialProperty GetById(int id)
        {
            var ResidentialProperty = MyData.ResidentialProperties.FirstOrDefault(x => x.Id == id);
            if (ResidentialProperty is null) return null!;
            return ResidentialProperty;
        }

        public List<ResidentialProperty> GetByName(string title)
        {
            List<ResidentialProperty> ResidentialProperties = [];

            foreach (var r in MyData.ResidentialProperties)
            {
                if (r.Title.ToLower().Contains(title.ToLower()))
                    ResidentialProperties.Add(r);
            }

            return ResidentialProperties;
        }

        public List<ResidentialProperty> GetAll()
        {
            return MyData.ResidentialProperties;
        }
    }
}
