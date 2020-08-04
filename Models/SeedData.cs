using Houseplants.DataAccess;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Houseplants.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            HouseplantContext context = app.ApplicationServices
            .GetRequiredService<HouseplantContext>();

            context.Database.Migrate();

            if (context.Houseplants.Count() == 0)
            {
                context.Houseplants.AddRange(
                new Houseplant
                {
                    //HouseplantId = 1,
                    Name = "Kwiat1",
                    NameLatin = "KwiatLat1",
                    BuyDate = DateTime.Today,
                    LastPlantDate = DateTime.Today,
                    PlaceName = "Nasłonecznione",
                    IrrigationDescription = "2 razy w tygodniu",
                    Fertigation = "2 razy w miesiącu nawóz: NPK"
                },
                new Houseplant
                {
                    //HouseplantId = 2,
                    Name = "Kwiat2",
                    NameLatin = "KwiatLat2",
                    BuyDate = DateTime.Today,
                    LastPlantDate = DateTime.Today,
                    PlaceName = "Nasłonecznione",
                    IrrigationDescription = "3 razy w tygodniu",
                    Fertigation = "3 razy w miesiącu nawóz: NPK"
                },
                new Houseplant
                {
                    //HouseplantId = 3,
                    Name = "Kwiat3",
                    NameLatin = "KwiatLat3",
                    BuyDate = DateTime.Today,
                    LastPlantDate = DateTime.Today,
                    PlaceName = "Nasłonecznione",
                    IrrigationDescription = "6 razy w tygodniu",
                    Fertigation = "6 razy w miesiącu nawóz: NPK"
                });
                context.SaveChanges();
            }
        }
    }
}
