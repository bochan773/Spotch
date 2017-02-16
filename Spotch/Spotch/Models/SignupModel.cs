using Newtonsoft.Json;
namespace Spotch.Models
{
    [JsonObject]
    class SignupModel
    {
        [JsonProperty(PropertyName = "result")]
        public bool result { set; get; }

        [JsonProperty(PropertyName = "userId")]
        public long userId { set; get; }

    }
}
