using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Houseplants.Models
{
    public class PictureHouseplant
    {
        public int PictureHouseplantId { get; set; }
        public byte[] Picture { get; set; }
    }
}
