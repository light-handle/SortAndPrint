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
        List<Content> contentList = new List<Content>();
        Content content = new Content();

        public List<Content> ReadFiles(string path)
        {
            Console.WriteLine("Path is " + path);
            if (File.Exists(path))
            {
                content = ProcessFile(path);
            }
            else if (Directory.Exists(path))
            {
                contentList = ProcessDirectory(path);
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", path);
            }
            return contentList;
        }

        private List<Content> ProcessDirectory(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                content = ProcessFile(fileName);
                contentList.Add(content);
            }
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                contentList = ProcessDirectory(subdirectory);
            }

            return contentList;
        }

        // Process files.
        private Content ProcessFile(string path)
        {
            var content = new Content();

            content.FileName = Path.GetFileName(path);

            content.FolderName = Path.GetFileName(Path.GetDirectoryName(path));

            StreamReader reader = new StreamReader(path);
            string fileContent = reader.ReadLine();
            content.FileContent = fileContent;

            return content;
        }
    }
}
