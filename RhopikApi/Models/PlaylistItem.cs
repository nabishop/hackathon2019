namespace RhopikApi.Models
{

    public class PlaylistItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Vibe { get; set; }
        public string DateAdded { get; set; }
        public long UserId { get; set; }
        public long SongId { get; set; }
    }
}

