using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortAndPrint
{
    // Reader class contains functions to read the directories and files
    public class Reader : IReader
    {
        public List<Content> readFiles(String path)
        {
            List<Content> contentList = new List<Content>();

            if (File.Exists(path))
            {
                // This path is a file
                ProcessFile(path);
            }
            else if (Directory.Exists(path))
            {
                // This path is a directory
                ProcessDirectory(path);
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", path);
            }
            return contentList;
        }

        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        private void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        // Process files.
        private void ProcessFile(string path)
        {
            Console.WriteLine("Processed file '{0}'.", path);
        }
    }
}
