using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Houseplants.Models
{
    public interface IHouseplantRepository
    {
        IQueryable<Houseplant> Houseplants { get; }
        void SaveHouseplant(Houseplant houseplant);
    }
}
