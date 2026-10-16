using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using Client.Interfaces;

namespace Client.Repositories;

// läser och skriver en lista av T till en json-fil
public class Storage<T> : IStorage<T> where T : class
{
    // samma inställningar för läsning och skrivning
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public List<T> Read(string path)
    {
        // finns ingen fil än får vi en tom lista
        if (!File.Exists(path))
        {
            return new List<T>();
        }

        var json = File.ReadAllText(path);
        var items = JsonSerializer.Deserialize<List<T>>(json, _options);

        return items ?? new List<T>();
    }

    public void Write(string path, List<T> data)
    {
        var directory = Path.GetDirectoryName(path);
        if (directory is not null)
        {
            Directory.CreateDirectory(directory);
        }

        var json = JsonSerializer.Serialize(data, _options);
        File.WriteAllText(path, json);
    }
}
