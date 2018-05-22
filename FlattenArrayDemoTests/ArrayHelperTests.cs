using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlattenArrayDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlattenArrayDemo.Tests
{
    [TestClass()]
    public class ArrayHelperTests
    {
        private ArrayHelper helper = new ArrayHelper();

        [TestMethod()]
        public void NestedIntArray()
        {
            var expected = new int[] { 1, 3, 5, 7, 0, 2, 4, 6, 8, 10, 11, 22, 99, 88, 0, 9 };
            var nestedIntArray = new int[3][,]
            {
                new int[,] { {1,3}, {5,7} },
                new int[,] { {0,2}, {4,6}, {8,10} },
                new int[,] { {11,22}, {99,88}, {0,9} }
            };
      
            var actual = helper.Flatten(nestedIntArray);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NestedEmptyArray()
        {
            var expected = new int[0];
            var nestedEmptyArray = new int[3][,]
            {
                new int[,] { {}, {} },
                new int[,] { {}, {}, {} },
                new int[,] { {}, {}, {} }
            };

            var actual = helper.Flatten(nestedEmptyArray);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EmptyArray()
        {
            var expected = new int[0];
            var emptyArray = new int[0];

            var actual = helper.Flatten(emptyArray);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NullArray()
        {
            var expected = new int[0];
            int[] nullArray = null;

            var actual = helper.Flatten(nullArray);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ArrayContainingNull()
        {
            var expected = new int[0];
            var nullArray = new string[] { null } ;

            var actual = helper.Flatten(nullArray);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NestedArrayContainingNull()
        {
            var expected = new int[] { 1, 3, 5, 7, 0, 2, 4, 6, 8, 10, 11, 22, 99, 88, 0 };
            var nestedObjectArray = new Object[3][,]
            {
                new Object[,] { {1,3}, {5,7} },
                new Object[,] { {0,2}, {4,6}, {8,10} },
                new Object[,] { {11,22}, {99,88}, {0,null} }
            };

            var actual = helper.Flatten(nestedObjectArray);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void StringArray()
        {
            var expected = new int[0];
            var nestedObjectArray = new String[1][,]
            {
                new String[,] { {"a","b"}, {"c","d"} }
            };

            var actual = helper.Flatten(nestedObjectArray);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DoubleLayeredArray()
        {
            var expected = new int[] { 1, 2, 3, 4 };
            var nestedObjectArray = new Object[]
            {
                new Object[] 
                {
                    1,
                    2,
                    new Object[] { 3 }
                },
                4
            };

            var actual = helper.Flatten(nestedObjectArray);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}