using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotch.Models
{
    [JsonObject]
    class UserAccount
    {
        [JsonProperty(PropertyName = "userid")]
        public long user_id { set; get; }
        [JsonProperty(PropertyName = "pass")]
        public string password { set; get; }
        [JsonProperty(PropertyName = "username")]
        public string username { set; get; }
        [JsonProperty(PropertyName = "birthday")]
        public DateTime birthday { set; get; }
        [JsonProperty(PropertyName = "email")]
        public string email { set; get; }
    }
}
