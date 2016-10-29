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

        public async Task<List<Content>> ReadFiles(string path)
        {
            Console.WriteLine("Path is " + path);
            if (File.Exists(path))
            {
                content = await ProcessFile(path);
                contentList.Add(content);
            }
            else if (Directory.Exists(path))
            {
                contentList = await ProcessDirectory(path);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            return contentList;
        }

        private async Task<List<Content>> ProcessDirectory(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                content = await ProcessFile(fileName);
                contentList.Add(content);
            }
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                contentList = await ProcessDirectory(subdirectory);
            }

            return contentList;
        }

        private async Task<Content> ProcessFile(string path)
        {
            var content = new Content
            {
                FolderName = Path.GetFileName(Path.GetDirectoryName(path)),
                FileName = Path.GetFileName(path)
            };

            using (StreamReader reader = new StreamReader(path))
            {
                content.FileContent = Convert.ToInt32(await reader.ReadLineAsync());
            }
            
            return content;
        }
    }
}
