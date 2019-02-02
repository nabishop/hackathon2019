using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RhopikApi.Models
{
   
    public class SongItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Length { get; set; }
    }
}

