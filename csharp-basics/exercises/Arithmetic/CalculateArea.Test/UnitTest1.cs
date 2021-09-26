using NUnit.Framework;
using System;


namespace CalculateArea.Test
{       
    public class Tests
    {
        private double _expectedResult;       

        [Test]
        public void AreaOfCircle_AreaOfRadius5_CalculatesArea()
        {
            // Arrange
            _expectedResult = Math.PI * 25;

            // Act
            double result = Geometry.AreaOfCircle(5);
            
            // Assert
            Assert.AreEqual(_expectedResult, result, 0.001, "78.54 is an area of Circle of radius 5");
        }

        [Test]
        public void AreaOfCircle_NegativeRadiusInput_ExceptionThrown()
        {
            //Assert           
            Assert.Throws<NotPositiveArgumentException>(() => Geometry.AreaOfCircle(-5),"No Exception thrown!");          
        }

        [Test]
        public void AreaOfRectangle_AreaOf25_CalculatesArea()
        {
            // Arrange
            _expectedResult = 5 * 5;

            //Act
            double result = Geometry.AreaOfRectangle(5,5);

            //Assert
            Assert.AreEqual(_expectedResult, result, 0.001, "25 is an area of Rectangle of 5 x 5");
        }

        [Test]
        public void AreaOfRectangle_NegativeArgumentArea_ThrowException()
        {
            //Assert
            Assert.Throws<NotPositiveArgumentException>(() => Geometry.AreaOfRectangle(-5, 5), "No Exception thrown!");           
        }

        [Test]
        public void AreaOfTriangle_AreaOfTriangle_CalculatesArea()
        {
            // Arrange
            _expectedResult = 12.5;

            //Act
            double result = Geometry.AreaOfTriangle(5, 5);

            //Assert
            Assert.AreEqual(_expectedResult, result, 0.001, "12.5 is an area of Rectangle of h5 x b5");
        }

        [Test]
        public void AreaOfTriangle_NegativeArgumentArea_ThrowException()
        {
            //Assert
            Assert.Throws<NotPositiveArgumentException>(() => Geometry.AreaOfTriangle(-5, 5), "No Exception thrown!");
        }
    }
}