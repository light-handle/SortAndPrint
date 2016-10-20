using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace SortAndPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfFiles;
            string dataDirectory = ConfigurationManager.AppSettings["datadirectory"];

            SetUpData setUpData = new SetUpData();
            setUpData.createFoldersAndFiles(dataDirectory, out countOfFiles);
            Console.WriteLine("Total files created {0}", countOfFiles);

            IReader reader = new Reader();
            List<Content> contentList = reader.ReadFiles(dataDirectory);

            ISorter sorter = new Sorter();
            List<Content> sortedList = sorter.SortByFileNameAlphabetically(contentList);

            IPrinter printer = new Printer();
            printer.PrintFilesAndFolders(sortedList);
        }
    }
}
