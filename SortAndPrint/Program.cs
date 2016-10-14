using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAndPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            SetUpData setUpData = new SetUpData();
            string dataDirectory = setUpData.createFoldersAndFiles();

            Reader reader = new Reader();
            List<Content> contentList = reader.readFiles(dataDirectory);
        }
    }
}
