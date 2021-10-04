using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public interface IFileReader
    {
        string ReadData(string path);
    }
}
