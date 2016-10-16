using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAndPrint
{
    class Sorter : ISorter
    {
        public List<Content> SortByFileNameAlphabetically(List<Content> contentList)
        {
            List<Content> sortedList = contentList.OrderBy(o => o.FileContent).ToList();

            return sortedList;
        }
    }
}
