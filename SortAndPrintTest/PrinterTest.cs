using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAndPrint;
using System.Collections.Generic;

namespace SortAndPrintTest
{
    [TestClass]
    public class PrinterTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Content List is empty or null.")]
        public void ShoudlThrowExceptionWhenContentListIsEmpty()
        {
            List<Content> emptyContentList = new List<Content>();

            ISorter sorter = new Sorter();
            sorter.SortByFileNameAlphabetically(emptyContentList);
        }
    }
}
