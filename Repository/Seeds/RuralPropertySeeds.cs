using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Repository.VirtualDatabase;

namespace Repository.Seeds
{
    public static class RuralPropertySeeds
    {
        public static void Seed()
        {
            if (MyData.RuralProperties.Count < 1)
            {
                RuralProperty r1 = new RuralProperty
                {
                    Id = 1,
                    Title = "Casa do Joao",
                    Description = "Excelente propriedade rural com solo fértil, nascente própria e área totalmente cercada, ideal para cultivo ou criação.",
                    BusinessType = TypeOfBusiness.Venda,
                    Price = 450000.00m,
                    Location = "Linha São Pedro, Videira - SC",
                    RoomSpecification = "3 quartos, 2 banheiros, sala de estar e cozinha caipira com fogão a lenha",
                    Hectares = 12.5,
                    HasWaterSource = true,
                    HasMainHouse = true,
                    ImageUrl = "/assets/images/ruralProperty/joao.jpg"
                };

                RuralProperty r2 = new RuralProperty
                {
                    Id = 2,
                    Title = "Casa do marcos",
                    Description = "Chácara aconchegante e reservada, perfeita para descanso de fim de semana ou locação por temporada.",
                    BusinessType = TypeOfBusiness.Aluguel,
                    Price = 2200.00m,
                    Location = "Linha Rio das Pedras, Videira - SC",
                    RoomSpecification = "2 quartos, 1 banheiro social, sala e cozinha integradas e varanda ampla",
                    Hectares = 3.8,
                    HasWaterSource = false,
                    HasMainHouse = true,
                    ImageUrl = "/assets/images/ruralProperty/marcos.jpg"
                };

                RuralProperty r3 = new RuralProperty
                {
                    Id = 3,
                    Title = "Casa do Isaias",
                    Description = "Sítio de grande porte com infraestrutura completa, riacho cristalino cortando a propriedade, pastagem formada e mata nativa preservada.",
                    BusinessType = TypeOfBusiness.Venda,
                    Price = 1250000.00m,
                    Location = "Interior, Tangará - SC",
                    RoomSpecification = "4 quartos, sendo 2 suítes, 3 banheiros, área de festas com churrasqueira e casa de ferramentas",
                    Hectares = 45.0,
                    HasWaterSource = true,
                    HasMainHouse = true,
                    ImageUrl = "/assets/images/ruralProperty/isaias.jpg"
                };

                // Adicionando as propriedades criadas à base de dados virtual
                MyData.RuralProperties.Add(r1);
                MyData.RuralProperties.Add(r2);
                MyData.RuralProperties.Add(r3);
            }
        }
    }
}
