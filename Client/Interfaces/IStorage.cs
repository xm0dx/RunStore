using System.Collections.Generic;

namespace Client.Interfaces;

// det som en lagring måste kunna: läsa och skriva en lista
public interface IStorage<T> where T : class
{
    List<T> Read(string path);
    void Write(string path, List<T> data);
}
