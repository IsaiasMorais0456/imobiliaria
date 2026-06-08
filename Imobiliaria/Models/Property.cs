namespace Imobiliaria.Models
{

    public enum TypeOfBusiness
    {
        Venda,
        Aluguel
    }
    public enum PropertyCategory
    {
        Comercial,
        Residencial,
        Rural
    }
    public class Property
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public PropertyCategory Category { get; set; }
        public TypeOfBusiness BusinessType { get; set; }
        public decimal Price { get; set; } 
        public string Location { get; set; }
        public string RoomSpecification { get; set; }
    }
}
