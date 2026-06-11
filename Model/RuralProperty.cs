namespace Model
{
    public class RuralProperty : Property 
    {
        public double Hectares { get; set; }
        public bool HasWaterSource { get; set; } 
        public bool HasMainHouse { get; set; }

        public RuralProperty()
        {
            // Sempre que um imóvel rural for criado, a categoria já nasce configurada corretamente
            Category = PropertyCategory.Rural;
        }
    }
}
