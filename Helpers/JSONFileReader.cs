using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Models;
using Newtonsoft.Json;

namespace Hello_World_Razor_Page.Helpers
{
    public class JsonFileReader
    {
        public Dictionary<int, Boat> ReadJson(string filePath)
        {
            string jsonstring = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<int, Boat>>(jsonstring);
            
        }
    }
}
