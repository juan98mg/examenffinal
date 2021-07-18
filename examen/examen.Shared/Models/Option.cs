using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace examen.Models
{
    public class Option
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
