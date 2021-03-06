using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Models;
using Newtonsoft.Json;

namespace Hello_World_Razor_Page.Helpers
{
    public class JsonFileWriter
    {
        public static void WriteToJsonBoat(List<Boat> boats,string filePath)
        {
            string output = JsonConvert.SerializeObject(boats);
            File.WriteAllText(filePath,output);
        }

        public static void WriteToJsonMember(List<Member> members, string filePath)
        {
            string output = JsonConvert.SerializeObject(members);
            File.WriteAllText(filePath,output);
        }
    }
}
