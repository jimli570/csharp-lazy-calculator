using System.Collections.Generic;

namespace Calculator.fileReader
{
    public interface IReader<T>
        where T : class
    {
        List<T> Read(string filePath);
    }
}
