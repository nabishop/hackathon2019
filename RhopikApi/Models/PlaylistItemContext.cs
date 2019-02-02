using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace RhopikApi.Models
{
    public class PlaylistItemContext : DbContext
    {
        public PlaylistItemContext(DbContextOptions<PlaylistItemContext> options)
            : base(options)
        {
        }

        public DbSet<PlaylistItem> PlaylistItems { get; set; }
    }
}