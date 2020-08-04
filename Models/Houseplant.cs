using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Houseplants.Models
{
    public class Houseplant
    {
        public int HouseplantId { get; set; }
        public string Name { get; set; }
        public string NameLatin { get; set; }
        public byte[] Thumbnail { get; set; } //picture
        public PictureHouseplant Gallery { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime LastPlantDate { get; set; } //data ostatniego przesadzenia
        public string PlaceName { get; set; } // nazwa stanowisko, gdzie rośnie
        public string IrrigationDescription { get; set; } //opis cykliczności nawadniania (podlewania)
        public string Fertigation { get; set; }

        [NotMapped]
        [DisplayName("Dodaj zdjęcie")]
        public IFormFile ImageFile { get; set; }
    }
}
