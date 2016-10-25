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
            if (contentList == null || contentList.Count == 0)
            {
                throw new ArgumentNullException();
            }
            else
            {
                foreach (Content content in contentList)
                {
                    Console.WriteLine($"Folder Name is {content.FolderName} || File Name is {content.FileName} || File Contents are {content.FileContent}");
                }
            }
        }
    }
}
