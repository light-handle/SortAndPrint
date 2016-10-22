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
            if(contentList.Count == 0 || contentList == null)
            {
                throw new Exception();
            }
            else
            {
                List<Content> sortedList = contentList.OrderBy(o => o.FileContent).ToList();

                return sortedList;
            }          
        }
    }
}
