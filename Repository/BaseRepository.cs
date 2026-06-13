using Model;
using Repository.VirtualDatabase;

namespace Repository
{
    public class BaseRepository<T>
    {
        public int GetNextId(T type)
        {
            switch (typeof(T))
            {
                case Type t when t == typeof(RuralProperty):
                    return GetNextRuralPropertyId();
                case Type t when t == typeof(CommercialProperty): //trocar para o comercial
                    return GetNextCommercialPropertyId();
                //case Type t when t == typeof(Product): // trocar para o Residencial
                //    return GetNextProductId();
                default:
                    throw new ArgumentException("Invalid type");
            }
        }

        private int GetNextRuralPropertyId()
        {

            int maxId = 0;

            foreach (var property in MyData.Properties)
            {
                if (property.Id > maxId)
                    maxId = property.Id;
            }
            return ++maxId;
        }

        private int GetNextCommercialPropertyId() //Comercial
        {

            int maxId = 0;
            foreach (var property in MyData.Properties)
            {
                if (property.Id > maxId)
                    maxId = property.Id;
            }
            return ++maxId;
        }

        //private int GetNextProductId() //Residencial
        //{

        //    int maxId = 0;
        //    foreach (var product in MyData.Products)
        //    {
        //        if (product.Id > maxId)
        //            maxId = product.Id;
        //    }
        //    return ++maxId;
        //}
    }
}
