using System.Collections.Generic;

namespace RateMyAnime.Models
{
    public class Episodes
    {
        public Pagination pagination { get; set; }
        public List<Datum> data { get; set; }
    }

    public class Datum
    {
        public int mal_id { get; set; }
        //public string url { get; set; }
        public string title { get; set; }
        //public string title_japanese { get; set; }
        //public string title_romanji { get; set; }
        //public DateTime aired { get; set; }
        public double? score { get; set; }
        //public bool filler { get; set; }
        //public bool recap { get; set; }
        //public string forum_url { get; set; }
    }

    public class Pagination
    {
        public int last_visible_page { get; set; }
        public bool has_next_page { get; set; }
    }
}
