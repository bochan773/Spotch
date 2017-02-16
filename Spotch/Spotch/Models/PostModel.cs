
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using Xamarin.Forms.GoogleMaps;

namespace Spotch.Models
{
    [JsonObject]
    public class PostModel
    {
        public PostModel()
        {
            userId = 1;
        }
        [JsonProperty(PropertyName = "postId")]
        public long postId { set; get; }

        [JsonProperty(PropertyName = "userId")]
        public long userId { set; get; }

        [JsonProperty(PropertyName = "latitude")]
        public double latitude { set; get; }

        [JsonProperty(PropertyName = "longitude")]
        public double longitude { set; get; }

        [JsonProperty(PropertyName = "content")]
        public string message { set; get; }

        [JsonProperty(PropertyName = "createAt")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime createAt { set; get; }

    }
}