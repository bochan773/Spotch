
using Newtonsoft.Json;
using System;
using Xamarin.Forms.GoogleMaps;

namespace Spotch.Models
{
    [JsonObject]
    public class Post
    {
        // test code
        public Post()
        {
            // test code
            postId = 1;
            userId = 1;
        }

        [JsonProperty(PropertyName = "postId")]
        public long postId { set; get; }

        [JsonProperty(PropertyName = "userId")]
        public long userId { set; get; }

        [JsonProperty(PropertyName = "content")]
        public string content { set; get; }

        [JsonProperty(PropertyName = "latitude")]
        public double latitude { set; get; }

        [JsonProperty(PropertyName = "longitude")]
        public double longitude { set; get; }

        [JsonProperty(PropertyName = "createAt")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime createAt { set; get; }
    }
}