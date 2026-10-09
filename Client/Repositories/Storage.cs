using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Client.Interface;

namespace Client.Repositories
{
    public class Storage<T> : Istorage<T> where T : class
    {
        public List<T> Read(string path)
        {
            if (!File.Exists(path))
                return new List<T>(); // return an empty list if the file doesn't exist

            var json = File.ReadAllText(path);
            var items = JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // ignore case when deserializing JSON
            });
            return items ?? new List<T>(); // deserialize the JSON string to a list of T objects
        }

        public void Write(string path, List<T> data)
        {
            var directory = Path.GetDirectoryName(Path.GetFullPath(path));
            if (directory is not null)
                Directory.CreateDirectory(directory);

            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            File.WriteAllText(path, json);
        }
    }
}
