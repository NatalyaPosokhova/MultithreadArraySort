using NUnit.Framework;

namespace MultithreadArraySort.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MergeTwoArraysShouldBeSortedArray()
        {
            //arrange
            int[] leftArray = new int[] {2, 5};
            int[] rightArray = new int[] { 4, 8};

            int[] expected = new int[] { 2, 4, 5, 8 };

            //act
            int[] actual = MultithreadMergeSort.Merge(leftArray, rightArray);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}