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

            IReader reader = new Reader();
            List<Content> contentList = reader.ReadFiles(dataDirectory);

            ISorter sorter = new Sorter();
            List<Content> sortedList = sorter.SortByFileNameAlphabetically(contentList);

            IPrinter printer = new Printer();
            printer.PrintFilesAndFolders(sortedList);
        }
    }
}
