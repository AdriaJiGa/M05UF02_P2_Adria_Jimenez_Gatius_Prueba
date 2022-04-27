using Microsoft.VisualStudio.TestTools.UnitTesting;
using M05UF02_P2_ProyectoSorting_Adria_Jimenez_Gatius;
using System;
using System.Linq;

namespace SortingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {//Arrange
            Random random = new Random();
            SortingArray sortArray = new SortingArray(10000, random);

            int[] temp = new int[sortArray.array.Length];
            Array.Copy(sortArray.array, temp,sortArray.array.Length);

            //act
            sortArray.BubbleSort(temp);

            //Assert
            
            Assert.IsTrue(Enumerable.SequenceEqual(temp, sortArray.arrayCreciente));



        }
    }
}
