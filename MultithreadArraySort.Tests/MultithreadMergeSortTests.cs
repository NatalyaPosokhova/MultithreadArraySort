using NUnit.Framework;
using System.Threading.Tasks;

namespace MultithreadArraySort.Tests
{
    public class Tests
    {
        private MergeSort _mergeSort;
        [SetUp]
        public void Setup()
        {
            _mergeSort = new MergeSort();
        }

        [Test]
        public void MergeTwoArraysShouldBeSortedArray()
        {
            //arrange
            int[] leftArray = new int[] {2, 5};
            int[] rightArray = new int[] { 4, 8};

            int[] expected = new int[] { 2, 4, 5, 8 };

            //act
            int[] actual = _mergeSort.Merge(leftArray, rightArray);

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
            int[] actual = _mergeSort.Merge(leftArray, rightArray);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TrySortEmptyArrayShouldReturnEmptyArray()
        {
            //arrange
            int[] expected = new int[] {};

            //act
            int[] actual = _mergeSort.Sort(expected);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TrySortOneLengthArrayShouldReturnOneLengthArray()
        {
            //arrange
            int[] expected = new int[] { 1 };

            //act
            int[] actual = _mergeSort.Sort(expected);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TrySortArrayShouldReturnSortedArray()
        {
            //arrange
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8};

            //act
            int[] actual = _mergeSort.Sort(new int[] { 8, 2, 7, 6, 1, 5, 3, 4 });

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TrySortOddArrayShouldReturnSortedArray()
        {
            //arrange
            int[] expected = new int[] { 1, 5, 7, 8, 10, 32, 44 };

            //act
            int[] actual = _mergeSort.Sort(new int[] { 7, 5, 8, 10, 44, 32, 1 });

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}