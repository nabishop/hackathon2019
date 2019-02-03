using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RhopikApi.Models
{
    public class PlaylistItem
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Name { get; set; }
        public string Vibe { get; set; }
        public string DateAdded { get; set; }
        public int Song_ID { get; set; }
        public int User_ID { get; set; }
    }
}
