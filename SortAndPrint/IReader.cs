using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SortAndPrint
{
    public interface IReader
    {
        Task<List<Content>> ReadFilesAsync(String path);
    }
}
