using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;

namespace Utils
{
    public static class JsonUtils
    {
        public static List<T> ReadFromFile<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                var jsonContent = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<T>>(jsonContent) ?? new List<T>();
            }
            return new List<T>();
        }

        public static void WriteToFile<T>(string filePath, List<T> data)
        {
            var jsonContent = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonContent);
        }
    
}

}
