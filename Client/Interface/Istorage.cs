using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Interface
{
    public interface Istorage<T> where T : class
    {
        List<T> Read(string path);
        void Write(string path, List<T> data);


    }
}
