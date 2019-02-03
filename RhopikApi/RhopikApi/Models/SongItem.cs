using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RhopikApi.Models
{
   
    public class SongItem
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int song_id { get; set; }
        public string name { get; set; }
        public string artist { get; set; }
        public string genre { get; set; }
        public string length { get; set; }
        public string album_covers { get; set; }
    }
}

