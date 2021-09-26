using NUnit.Framework;
using Exercise1;
using System.IO;
using System;

namespace Exercise1_Test
{
    public class Tests
    {
        private bool _expected;

        [Test]
        public void ReturnFifteens_BothNumbersEqual15_ReturnTrue()
        {
            //Act
            bool result = Exercise1.Program.ReturnFifteens(15, 15);

            //Arrange
            _expected = true;

            // Assert
            Assert.AreEqual(_expected, result, "Both of numbers are 15. Should be returned True");
        }

        [Test]
        public void ReturnFifteens_OneNumberEquals15_ReturnTrue()
        {
            //Act
            bool result = Exercise1.Program.ReturnFifteens(2, 15);

            //Arrange
            _expected = true;

            // Assert
            Assert.AreEqual(_expected, result, "One number is 15. Should be returned True");
        }

        [Test]
        public void ReturnFifteens_SumEquals15_ReturnTrue()
        {
            //Act
            bool result = Exercise1.Program.ReturnFifteens(7, 8);

            //Arrange
            _expected = true;

            // Assert
            Assert.AreEqual(_expected, result, "Sum is 15. Should be returned True");
        }

        [Test]
        public void ReturnFifteens_DiffEquals15_ReturnTrue()
        {
            //Act
            bool result = Exercise1.Program.ReturnFifteens(22, 7);

            //Arrange
            _expected = true;

            // Assert
            Assert.AreEqual(_expected, result, "Difference is 15. Should be returned True");
        }

        [Test]
        public void ReturnFifteens_Not15_ReturnFalse()
        {
            //Act
            bool result = Exercise1.Program.ReturnFifteens(4, 3);

            //Arrange
            _expected = false;

            // Assert
            Assert.AreEqual(_expected, result, "No of the actions equal 15. Should be returned False");
        }
    }
}