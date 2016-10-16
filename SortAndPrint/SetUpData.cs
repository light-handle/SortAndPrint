using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortAndPrint
{
    class SetUpData
    {
        Random random = new Random();
        String[] nameArray = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public string createFoldersAndFiles()
        {
            string dataDirectory;
            string currentDirectory = Directory.GetCurrentDirectory();
            dataDirectory = Path.Combine(currentDirectory, "Data");

            for (int folder = 1; folder <= 10; folder++)
            {                                       
                var completePath = Path.Combine(dataDirectory, folder.ToString());
                Directory.CreateDirectory(completePath);

                int noOfFiles = random.Next(1, 4);

                for(int i = 1; i <= noOfFiles; i++)
                {
                    var filePath = Path.Combine(completePath, i.ToString()+"file.txt");
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        sw.WriteLine(nameArray[random.Next(nameArray.Length)]);
                    }
                }   
            }
            Console.WriteLine("Data Successfully Set up....");
            return dataDirectory;
        }
    }
}
