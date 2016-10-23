using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAndPrint
{
    public class Sorter : ISorter
    {
        public List<Content> SortByFileNameAlphabetically(List<Content> contentList)
        {
            if(contentList == null || contentList.Count == 0)
            {
                throw new ArgumentNullException();
            }
            else
            {
                List<Content> sortedList = contentList.OrderBy(o => o.FileContent).ToList();

                return sortedList;
            }          
        }
    }
}
