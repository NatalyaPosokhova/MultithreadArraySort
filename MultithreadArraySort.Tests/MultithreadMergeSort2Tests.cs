using NUnit.Framework;
using System.Threading.Tasks;

namespace MultithreadArraySort.Tests
{
    public class MultithreadMergeSort2Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MergeTwoArraysShouldBeSortedArray()
        {
            //arrange
            int[] leftArray = new int[] { 2, 5 };
            int[] rightArray = new int[] { 4, 8 };

            int[] expected = new int[] { 2, 4, 5, 8 };

            //act
            int[] actual = MultithreadMergeSort2.Merge(leftArray, rightArray);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MergeTwoArraysWithThreeElementsShouldBeSortedArray()
        {
            //arrange
            int[] leftArray = new int[] { 1, 6, 8 };
            int[] rightArray = new int[] { 2, 4, 7 };

            int[] expected = new int[] { 1, 2, 4, 6, 7, 8 };

            //act
            int[] actual = MultithreadMergeSort2.Merge(leftArray, rightArray);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task TrySortEmptyArrayShouldReturnEmptyArray()
        {
            //arrange
            int[] expected = new int[] { };

            //act
            int[] actual = await MultithreadMergeSort2.SortAsync(expected);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task TrySortOneLengthArrayShouldReturnOneLengthArray()
        {
            //arrange
            int[] expected = new int[] { 1 };

            //act
            int[] actual = await MultithreadMergeSort2.SortAsync(expected);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task TrySortArrayShouldReturnSortedArray()
        {
            //arrange
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            //act
            int[] actual = await MultithreadMergeSort2.SortAsync(new int[] { 8, 2, 7, 6, 1, 5, 3, 4 });

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task TrySortOddArrayShouldReturnSortedArray()
        {
            //arrange
            int[] expected = new int[] { 1, 5, 7, 8, 10, 32, 44 };

            //act
            int[] actual = await MultithreadMergeSort2.SortAsync(new int[] { 7, 5, 8, 10, 44, 32, 1 });

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
