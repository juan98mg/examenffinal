using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace examen.Models
{
    public class Question
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("options")]
        public List<Option> Options { get; set; }

    }
}
