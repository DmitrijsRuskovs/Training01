using NUnit.Framework;

namespace CheckOddEven.Test
{
    public class Tests
    {
        private bool _expected;

        [Test]
        public void IsIntegerOdd_EvenNumberInput_ReturnsFalse()
        {
            //Act
            bool result = CheckOddEven.Program.IsIntegerOdd(4);

            //Arrange
            _expected = false;

            // Assert
            Assert.AreEqual(_expected, result, "Even number. Should be returned False");
        }

        [Test]
        public void IsIntegerOdd_OddNumberInput_ReturnsTrue()
        {
            //Act
            bool result = CheckOddEven.Program.IsIntegerOdd(13);

            //Arrange
            _expected = true;

            // Assert
            Assert.AreEqual(_expected, result, "Odd number. Should be returned True");
        }

        [Test]
        public void IsIntegerOdd_NegativeOddInput_ReturnsTrue()
        {
            //Act
            bool result = CheckOddEven.Program.IsIntegerOdd(-13);

            //Arrange
            _expected = true;

            // Assert
            Assert.AreEqual(_expected, result, "Odd negative number. Should be returned True");
        }

        [Test]
        public void IsIntegerOdd_ZeroInput_ReturnsFalse()
        {
            //Act
            bool result = CheckOddEven.Program.IsIntegerOdd(0);

            //Arrange
            _expected = false;

            // Assert
            Assert.AreEqual(_expected, result, "Zero is Even number. Should be returned False");
        }
    }
}