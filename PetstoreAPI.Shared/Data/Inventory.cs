using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PetstoreAPI.Data
{
    public class Inventory
    {
        [JsonPropertyName("sold")]

        public int Sold { get; set; }
        public int NA { get; set; }
        public int String { get; set; }
        public int NotExist { get; set; }
        public int Available { get; set; }
        public int Pending { get; set; }
        public int Avalible { get; set; }
        public int Bold { get; set; }
    }
}
