using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAndPrint;
using System.Collections.Generic;

namespace SortAndPrintTest
{
    [TestClass]
    public class ReaderTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Invalid Path Specified.")]
        public void ShouldReturnValidationErrorWhenAnEmptyPathIsSpecified()
        {
            string emptyPath = "";

            IReader reader = new Reader();
            List<Content> contentList = reader.ReadFiles(emptyPath);
        }

        [TestMethod]
        public void ShouldReturnAListOfContents()
        {
            string path = "Mock";

            IReader reader = new Reader();
            List<Content> actualContentList = reader.ReadFiles(path);

            var expectedContent = new Content
            {
                FolderName = "Mock",
                FileName = "34e4a0ad-e9d4-45d4-8967-e2e46330e096.txt",
                FileContent = 227
            };

            List<Content> expectedContentList = new List<Content>();
            expectedContentList.Add(expectedContent);

            CollectionAssert.AreEqual(expectedContentList, actualContentList, new ContentListComparer());
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

                return string.Compare(Convert.ToString(x.FileContent), Convert.ToString( y.FileContent));
            }
        }
    }
}
