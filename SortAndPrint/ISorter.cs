using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAndPrint
{
    public interface ISorter
    {
        List<Content> SortByFileNameAlphabetically(List<Content> listContent);
    }
}
