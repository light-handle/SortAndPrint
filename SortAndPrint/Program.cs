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
            List<Content> contentList = new List<Content>();
            List<Content> sortedList = new List<Content>();

            try
            {
                SetUpData setUpData = new SetUpData();
                setUpData.createFoldersAndFiles(dataDirectory, out countOfFiles);
                Console.WriteLine("Total files created {0}", countOfFiles);

                IReader reader = new Reader();
                contentList = reader.ReadFiles(dataDirectory);
                
                ISorter sorter = new Sorter();
                sortedList = sorter.SortByFileNameAlphabetically(contentList);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("Invalid path specified. Cannot set up data.");
                Console.Error.WriteLine(ex);
                System.Environment.Exit(1);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Content List is empty or null.");
                Console.Error.WriteLine(ex);
                System.Environment.Exit(1);
            }

            

            IPrinter printer = new Printer();
            printer.PrintFilesAndFolders(sortedList);
        }
    }
}
