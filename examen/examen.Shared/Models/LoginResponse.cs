using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace examen.Models
{
    public class LoginResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expiration")]
        public DateTimeOffset expiration { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

    }
}
