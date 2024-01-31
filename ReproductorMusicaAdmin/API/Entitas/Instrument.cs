using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaAdmin.API.Entitas
{
    public class Instrument
    {
        [Key]
        public string? Name { get; set; } 

        public string? Type { get; set; }

        public ICollection<Play> Plays { get; set; } = new List<Play>();
    }
}
