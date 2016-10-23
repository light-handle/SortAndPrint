using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortAndPrint
{
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
                contentList.Add(content);
            }
            else if (Directory.Exists(path))
            {
                contentList = ProcessDirectory(path);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
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

        private Content ProcessFile(string path)
        {
            StreamReader reader = new StreamReader(path);

            var content = new Content
            {
                FolderName = Path.GetFileName(Path.GetDirectoryName(path)),
                FileName = Path.GetFileName(path),
                FileContent = Convert.ToInt32(reader.ReadLine())
             
            };

            return content;
        }
    }
}
