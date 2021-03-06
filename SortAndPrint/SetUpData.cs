﻿using System;
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

        public void createFoldersAndFiles(string dataDirectory, out int countOfFiles)
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
                            sw.WriteLine(random.Next(1, 500));
                        }
                        fileCount++;
                    }
                }
                countOfFiles = fileCount;
                Console.WriteLine("Data Successfully Set up....");
            }
        }
    }
}
