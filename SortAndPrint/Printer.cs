using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAndPrint
{
    class Printer : IPrinter
    {
        public void PrintFilesAndFolders(List<Content> contentList)
        {
            foreach (Content content in contentList)
            {
                Console.WriteLine("Folder Name is {0} || File Name is {1} || File Contents are {2}", content.FolderName, content.FileName, content.FileContent);
            }
        }
    }
}
