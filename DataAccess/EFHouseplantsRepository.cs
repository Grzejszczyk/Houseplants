using Houseplants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Houseplants.DataAccess
{
    public class EFHouseplantsRepository : IHouseplantRepository
    {
        private HouseplantContext context;
        public EFHouseplantsRepository(HouseplantContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Houseplant> Houseplants => context.Houseplants;

        public void SaveHouseplant(Houseplant houseplant)
        {
            if (houseplant.HouseplantId == 0)
            {
                context.Houseplants.Add(houseplant);
            } else
            {
                Houseplant dbEntry = context.Houseplants.FirstOrDefault(e => e.HouseplantId == houseplant.HouseplantId);
                if (dbEntry != null)
                {
                    dbEntry.Name = houseplant.Name;
                    dbEntry.NameLatin = houseplant.NameLatin;
                    dbEntry.Thumbnail = houseplant.Thumbnail;
                    //gallery
                    dbEntry.BuyDate = houseplant.BuyDate;
                    dbEntry.LastPlantDate = houseplant.LastPlantDate;
                    dbEntry.IrrigationDescription = houseplant.IrrigationDescription;
                    dbEntry.Fertigation = houseplant.Fertigation;
                }
            }
            context.SaveChanges();
        }
    }
}
