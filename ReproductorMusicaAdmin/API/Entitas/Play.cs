using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaAdmin.API.Entitas
{
    public class Play
    {
        public string? Bandname {  get; set; }
        public Band? Band { get; set; }

        public string? MusicianName { get; set; }
        public Musician? Musician { get; set; }

        public string? InstrumentName { get; set; }
        public Instrument? Instrument { get; set; }
       
        public Guid SongUID { get; set; }
        public Song? Song { get; set; }
    }
}
