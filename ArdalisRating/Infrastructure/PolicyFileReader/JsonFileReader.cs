using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArdalisRating
{
    public class JsonFileReader : IFileReader
    {
        public string ReadData(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
