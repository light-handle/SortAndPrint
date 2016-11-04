using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace SortAndPrint
{
    class SetUpData
    {
        Random random = new Random();

        public async Task createFoldersAndFilesAsync(string dataDirectory)
        {
            int fileCount = 0;
            int folderCount = Convert.ToInt32(ConfigurationManager.AppSettings["nooffolders"]);

            if (dataDirectory == "")
            {
                throw new ArgumentException();
            }
            else
            {
                for (int folder = 1; folder <= folderCount; folder++)
                {
                    var completePath = Path.Combine(dataDirectory, folder.ToString());
                    Directory.CreateDirectory(completePath);

                    int numberOfFiles = random.Next(1, 4);

                    for (int i = 1; i <= numberOfFiles; i++)
                    {
                        var filePath = Path.Combine(completePath, Guid.NewGuid() + ".txt");
                        using (StreamWriter sw = File.CreateText(filePath))
                        {
                            await sw.WriteLineAsync(Convert.ToString(random.Next(1, 500)));
                        }
                        fileCount++;
                    }
                }
                Console.WriteLine("Data Successfully Set up....");
            }
        }
    }
}
