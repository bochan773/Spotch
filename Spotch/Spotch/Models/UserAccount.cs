using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.GoogleMaps;

namespace Spotch.Models
{
    [JsonObject]
    class UserAccount
    {
        [JsonProperty(PropertyName = "userId")]
        public long userId { set; get; }
        [JsonProperty(PropertyName = "password")]
        public string password { set; get; }
        [JsonProperty(PropertyName = "userName")]
        public string userName { set; get; }
        [JsonProperty(PropertyName = "birthday")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime birthday { set; get; }
        [JsonProperty(PropertyName = "email")]
        public string email { set; get; }
    }
}
