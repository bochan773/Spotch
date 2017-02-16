using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotch.Models
{
    [JsonObject]
    class LoginModel
    {
        [JsonProperty(PropertyName = "password")]
        public string password { set; get; }
        [JsonProperty(PropertyName = "email")]
        public string email { set; get; }
    }
}
