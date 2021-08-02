using NUnit.Framework;

namespace CozaLozaWoza.Test
{
    public class Tests
    {
        private string _expected;

        [Test]
        public void CozaLozaWoza_Coza()
        {
            //Act
            string result = CozaLozaWoza.Program.CozaLozaWoza(9);

            //Arrange
            _expected = "Coza";

            // Assert
            Assert.AreEqual(_expected, result, "Coza should be returned for 9");
        }

        [Test]
        public void CozaLozaWoza_InputOf20_ExpectedOutputLoza()
        {
            //Act
            string result = CozaLozaWoza.Program.CozaLozaWoza(20);

            //Arrange
            _expected = "Loza";

            // Assert
            Assert.AreEqual(_expected, result, "Loza should be returned for 20");
        }

        [Test]
        public void CozaLozaWoza_InputOf14_ExpectedOutputWoza()
        {
            //Act
            string result = CozaLozaWoza.Program.CozaLozaWoza(14);

            //Arrange
            _expected = "Woza";

            // Assert
            Assert.AreEqual(_expected, result, "Woza should be returned for 14");
        }

        [Test]
        public void CozaLozaWoza_InputOf15_ExpectedOutputCozaLoza()
        {
            //Act
            string result = CozaLozaWoza.Program.CozaLozaWoza(15);

            //Arrange
            _expected = "CozaLoza";

            // Assert
            Assert.AreEqual(_expected, result, "CozaLoza should be returned for 15");
        }

        [Test]
        public void CozaLozaWoza_InputOf21_ExpectedOutputCozaWoza()
        {
            //Act
            string result = CozaLozaWoza.Program.CozaLozaWoza(21);

            //Arrange
            _expected = "CozaWoza";

            // Assert
            Assert.AreEqual(_expected, result, "CozaWoza should be returned for 21");
        }

        [Test]
        public void CozaLozaWoza_InputOf35_ExpectedOutputLozaWoza()
        {
            //Act
            string result = CozaLozaWoza.Program.CozaLozaWoza(35);

            //Arrange
            _expected = "LozaWoza";

            // Assert
            Assert.AreEqual(_expected, result, "LozaWoza should be returned for 35");
        }

        [Test]
        public void CozaLozaWoza_InputOf105_ExpectedOutputCozaLozaWoza()
        {
            //Act
            string result = CozaLozaWoza.Program.CozaLozaWoza(105);

            //Arrange
            _expected = "CozaLozaWoza";

            // Assert
            Assert.AreEqual(_expected, result, "CozaLozaWoza should be returned for 105");
        }

        [Test]
        public void CozaLozaWoza_InputOf41_ExpectedOutput41()
        {
            //Act
            string result = CozaLozaWoza.Program.CozaLozaWoza(41);

            //Arrange
            _expected = "41";

            // Assert
            Assert.AreEqual(_expected, result, "41 should be returned for 41");
        }
    }
}