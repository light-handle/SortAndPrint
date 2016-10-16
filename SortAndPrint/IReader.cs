using System;
using System.Collections.Generic;
using System.IO;

namespace SortAndPrint
{
    public interface IReader
    {
        List<Content> ReadFiles(String path);
    }
}
