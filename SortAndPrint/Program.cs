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
            string dataDirectory = ConfigurationManager.AppSettings["datadirectory"];
            List<Content> contentList = new List<Content>();
            List<Content> sortedList = new List<Content>();

            try
            {
                SetUpData setUpData = new SetUpData();
                setUpData.createFoldersAndFilesAsync(dataDirectory).Wait();

                IReader reader = new Reader();
                contentList = reader.ReadFilesAsync(dataDirectory).Result;
                
                ISorter sorter = new Sorter();
                sortedList = sorter.SortByFileNameAlphabetically(contentList);

                IPrinter printer = new Printer();
                printer.PrintFilesAndFolders(sortedList);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Invalid path specified. Cannot set up data.");
                Console.Error.WriteLine(ex);
                System.Environment.Exit(1);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine("Content List is empty or null.");
                Console.Error.WriteLine(ex);
                System.Environment.Exit(1);
            }         
        }
    }
}
