using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MSTestCookie.Utils
{
    class JsonReader
    {
        public static string GetParameter(string jsonData)
        {
            var data = JObject.Parse(File.ReadAllText("../../../Resources//TestData.json"));
            return (string)data[jsonData];
        }
    }
}
