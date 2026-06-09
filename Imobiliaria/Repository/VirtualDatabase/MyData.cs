using Imobiliaria.Models;
using System.Net;

namespace Imobiliaria.Repository.VirtualDatabase
{
    public static class MyData
    {
        public static List<Property> Properties = [];
        public static List<CommercialProperty> CommercialProperties = [];
        public static List<RuralProperty> RuralProperties = [];
    }
}
