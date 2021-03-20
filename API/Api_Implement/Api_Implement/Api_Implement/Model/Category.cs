using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api_Implement.Model
{
    public class Category
    {
        [JsonProperty("word")]
        public string Word { get; set; }

        [JsonProperty("hasCategories")]
        public List<string> Categories { get; set; }
    }
}
