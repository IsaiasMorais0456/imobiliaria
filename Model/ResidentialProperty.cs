using Model;

namespace Model
{
    public class ResidentialProperty : Property
    {
        public double Hectares { get; set; }
        public bool HasWaterSource { get; set; }
        public bool HasMainHouse { get; set; }

        public ResidentialProperty()
        {
            // Sempre que um imóvel rural for criado, a categoria já nasce configurada corretamente
            Category = PropertyCategory.Residencial;
        }
    }
}
