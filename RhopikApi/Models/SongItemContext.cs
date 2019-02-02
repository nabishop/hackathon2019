using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace RhopikApi.Models
{
    public class SongItemContext : DbContext
    {
        public SongItemContext(DbContextOptions<SongItemContext> options)
            : base(options)
        {
        }

        public DbSet<SongItem> SongItems { get; set; }
    }
}