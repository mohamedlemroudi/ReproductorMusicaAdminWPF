using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusicaAdmin.API.Entitas
{
    public class Song
    {
        [Key]
        public Guid UID { get; set; }
        public string Title { get; set; } = null!;
        public string? Language { get; set; }
        public int? Duration { get; set; }

        public Guid? VersionOriginalId { get; set; }
        public ICollection<Song> DerivedVersions { get; set; } = new List<Song>();
        public Song? OriginalSong { get; set; }

        public ICollection<Play> Plays { get; set; } = new List<Play>();
        public ICollection<Extension> Extensions { get; set; } = null!;
        public ICollection<PlayList> PlayLists { get; set; } = null!;

        public ICollection<Album> Albums { get; set; } = new List<Album>();

    }
}
