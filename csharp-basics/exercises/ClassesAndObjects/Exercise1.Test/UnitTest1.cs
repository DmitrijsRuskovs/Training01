using NUnit.Framework;

namespace Exercise1.Test
{
    public class Tests
    {
        //Arrange and Act
        private Product[] _products = { new Product("A", 20, 100), new Product("B", 1000, 5), new Product("C", 500, 3000) };

        [Test]
        public void Product_CheckSetMethodst_SetDataIsSavedAccordingToInput()
        {
            //Act
            _products[0].SetPrice(21);
            _products[0].SetQuantity(99);
            
            //Assert
            Assert.AreEqual(_products[0].GetPrice(), 21, 0.001, "Entry setter has not been saved correctly");
            Assert.AreEqual(_products[0].GetQuantity(), 99, 0.001, "Entry setter has not been saved correctly");
            
            //Act
            _products[0].SetPrice(20);
            _products[0].SetQuantity(100);
        }

        [Test]
        public void Product_CheckSetupEntryGetMethods_ConstructorInputDataEqualsToInput()
        {
            //Assert
            Assert.AreEqual(_products[0].GetPrice(), 20, 0.001, "Entry has not been saved correctly");
            Assert.AreEqual(_products[0].GetQuantity(), 100, 0.001, "Entry has not been saved correctly");
            Assert.AreEqual(_products[0].GetName(), "A", "Entry has not been saved correctly");        
        }

        [Test]
        public void Product_CheckWholeStockPriceValidity_WholeStockPriceEqualsTo2000()
        {
            //Assert
            Assert.AreEqual(_products[0].GetWholeStockPrice(), 2000, 0.001, "Whole stock price is calculated falsely");          
        }

        [Test]
        public void Product_CheckReport_ReportMethodOutputsCorrectDataAndFormat()
        {
            //Assert
            Assert.AreEqual(_products[0].PrintProduct(), "A, price: 20 EUR, amount: 100 units", "Report method does not work correctly");
        }      
    }
}