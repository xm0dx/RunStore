using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Interfaces
{
    public interface IStorage<T> where T : class
    {
        List<T> Read(string path);
        void Write(string path, List<T> data);


    }
}
