
using Newtonsoft.Json;
using System;
using Xamarin.Forms.GoogleMaps;

namespace Spotch.Models
{
    [JsonObject]
    public class Post
    {
        [JsonProperty(PropertyName = "message")]
        public string message { get; set; }

        [JsonProperty(PropertyName = "position")]
        public Position position { get; set; }

        [JsonProperty(PropertyName = "time")]
        public DateTime time { get; set; }
    }
}