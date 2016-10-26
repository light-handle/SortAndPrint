using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAndPrint;
using System.Collections.Generic;

namespace SortAndPrintTest
{
    [TestClass]
    public class SorterTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Content List is empty or null.")]
        public void ShoudlThrowExceptionWhenContentListIsEmpty()
        {
            List<Content> emptyContentList = new List<Content>();

            ISorter sorter = new Sorter();
            sorter.SortByFileNameAlphabetically(emptyContentList);
        }

        [TestMethod]
        public void ShouldReturnListSortedByFileContent()
        {
            List<Content> unsortedList = new List<Content>
            {
                new Content
                {
                    FolderName = "SortedMock",
                    FileName = "cd46fc09-73ee-4c6b-8c02-ca7ad48a359b.txt",
                    FileContent = 322
                },
                new Content
                {
                    FolderName = "SortedMock",
                    FileName = "34e4a0ad-e9d4-45d4-8967-e2e46330e096.txt",
                    FileContent = 227
                }
            };

            List<Content> expectedSortedList = new List<Content>
            {
                new Content
                {
                    FolderName = "SortedMock",
                    FileName = "34e4a0ad-e9d4-45d4-8967-e2e46330e096.txt",
                    FileContent = 227
                },
                new Content
                {
                    FolderName = "SortedMock",
                    FileName = "cd46fc09-73ee-4c6b-8c02-ca7ad48a359b.txt",
                    FileContent = 322
                }
            };

            ISorter sorter = new Sorter();
            List<Content> actualSortedList = sorter.SortByFileNameAlphabetically(unsortedList);

            CollectionAssert.AreEqual(expectedSortedList, actualSortedList, new ContentListComparer());
        }

        private class ContentListComparer : Comparer<Content>
        {
            public override int Compare(Content x, Content y)
            {
                int comparison = string.Compare(x.FolderName, y.FolderName);
                if (comparison != 0)
                    return comparison;

                comparison = string.Compare(x.FileName, y.FileName);
                if (comparison != 0)
                    return comparison;

                return string.Compare(Convert.ToString(x.FileContent), Convert.ToString(y.FileContent));
            }
        }
    }   
}
