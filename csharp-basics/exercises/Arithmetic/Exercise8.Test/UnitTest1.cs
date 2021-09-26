using NUnit.Framework;

namespace Exercise8.Test
{
    public class Tests
    {
        private Employee _testEmployee;
        private string _expected;
        private double _expectedSalary;

        [Test]
        public void Employee_LowPaidEmployee_ReturnErrorSalaryPayingMessage()
        {
            //Act
            _testEmployee = new Employee("Mister Jecabson", 7.50, 35);
            string message = _testEmployee.SalaryPayingMessage();

            //Arrange
            _expected = "Error! Not less than 8.00 USD/h are allowed according to US legislation!";

            // Assert
            Assert.AreEqual(_expected, message, "Error! Not less than 8.00 USD/h are allowed according to US legislation! is expected");
        }

        [Test]
        public void Employee_StandardEmployee_ReturnStandardOrderSalaryPayingMessage()
        {
            //Act
            _testEmployee = new Employee("Mister Jecabson", 8.0, 35);
            string message = _testEmployee.SalaryPayingMessage();

            //Arrange
            _expected = "To be paid in standard order";

            // Assert
            Assert.AreEqual(_expected, message, "To be paid in standard order is expected");
        }

        [Test]
        public void Employee_OverWorkingEmployee_ReturnErrorSalaryPayingMessage()
        {
            //Act
            _testEmployee = new Employee("Mister Jecabson", 8.50, 70);
            string message = _testEmployee.SalaryPayingMessage();

            //Arrange
            _expected = "Error! More than 60 hours worked!";

            // Assert
            Assert.AreEqual(_expected, message, "Error! More than 60 hours worked! is expected");
        }

        [Test]
        public void Employee_StandardWorkTimeSalary_StandardSalaryOf255()
        {
            //Act
            _testEmployee = new Employee("Mister Jecabson", 8.50, 30);
            double salary = _testEmployee.GetSalary();

            //Arrange
            _expectedSalary = 255;

            // Assert
            Assert.AreEqual(_expectedSalary, salary, 0.001, "255 USD is to be paid for 30h of 8.50 USD/h employee");
        }

        [Test]
        public void Employee_OverTimeWorkTimeSalary_OverTimeSalaryOf595()
        {
            //Act
            _testEmployee = new Employee("Mister Jecabson", 8.50, 60);
            double salary = _testEmployee.GetSalary();

            //Arrange
            _expectedSalary = 595;

            // Assert
            Assert.AreEqual(_expectedSalary, salary, 0.001, "595 USD is to be paid for 40h of 8.50 USD/h and 20 h overtime for employee");
        }
    }
}