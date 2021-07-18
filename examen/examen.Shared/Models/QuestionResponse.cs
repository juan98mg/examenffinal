using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace examen.Models
{
    class QuestionResponse
    {

        [JsonProperty("QuestionId")]
        public int QuestionId { get; set; }
        [JsonProperty("OptionId")]
        public int OptionId { get; set; }

    }
}
