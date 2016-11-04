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

        public async Task<List<Content>> ReadFilesAsync(string path)
        {
            var tasks = new List<Task>();

            //tasks.Add(ProcessFileAsync(path));

            Console.WriteLine("Path is " + path);
            if (File.Exists(path))
            {
                content = await ProcessFileAsync(path);
                //content = await Task.WhenAny(tasks).Result;
                contentList.Add(content);
            }
            else if (Directory.Exists(path))
            {
                contentList =  await ProcessDirectoryAsync(path);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            return contentList;
        }

        private async Task<List<Content>> ProcessDirectoryAsync(string targetDirectory)
        {
            var tasks = new List<Task>();

            //tasks.Add(ProcessFileAsync(path));

            //tasks.Add(ProcessFileAsync(path));

            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                content = await ProcessFileAsync(fileName);
                contentList.Add(content);
            }
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            /*foreach (string subdirectory in subdirectoryEntries)
            {
                contentList = await ProcessDirectoryAsync(subdirectory);
            }*/

            Parallel.ForEach(subdirectoryEntries, async (currentDirectory) =>
            {
                contentList = await ProcessDirectoryAsync(currentDirectory);
            });

            return contentList;
        }

        private async Task<Content> ProcessFileAsync(string path)
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
