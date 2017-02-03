
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
            id = 1;
        }

        [JsonProperty(PropertyName = "id")]
        public long id { set; get; }

        [JsonProperty(PropertyName = "userid")]
        public long user_id { set; get; }

        [JsonProperty(PropertyName = "content")]
        public string message { set; get; }

        public Position position { set; get; }

        [JsonProperty(PropertyName = "x")]
        public double x
        {
            set
            {
                this.x = this.position.Latitude;
            }
            get
            {
                return this.x;
            }
        }

        [JsonProperty(PropertyName = "y")]
        public double y
        {
            set
            {
                this.y = this.position.Longitude;
            }
            get
            {
                return this.y;
            }
        }

        [JsonProperty(PropertyName = "time")]
        public DateTime time { get; set; }
    }
}