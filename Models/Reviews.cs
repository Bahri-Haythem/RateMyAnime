using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RateMyAnime.Models
{
    public class Reviews
    {
        public string request_hash { get; set; }
        public bool request_cached { get; set; }
        public int request_cache_expiry { get; set; }
        public bool API_DEPRECATION { get; set; }
        public DateTime API_DEPRECATION_DATE { get; set; }
        public string API_DEPRECATION_INFO { get; set; }
        public List<Review> reviews { get; set; }
    }

    public class Scores
    {
        public int overall { get; set; }
        public int story { get; set; }
        public int animation { get; set; }
        public int sound { get; set; }
        public int character { get; set; }
        public int enjoyment { get; set; }
    }

    public class Reviewer
    {
        public string url { get; set; }
        public string image_url { get; set; }
        public string username { get; set; }
        public int episodes_seen { get; set; }
        public Scores scores { get; set; }
    }

    public class Review
    {
        public int mal_id { get; set; }
        public string url { get; set; }
        public object type { get; set; }
        public int helpful_count { get; set; }
        public DateTime date { get; set; }
        public Reviewer reviewer { get; set; }
        [JsonIgnore]
        public string content { get; set; }
    }
}
