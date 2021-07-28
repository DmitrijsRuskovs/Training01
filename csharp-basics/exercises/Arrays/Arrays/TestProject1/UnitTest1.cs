using NUnit.Framework;
using ArrayX6;

namespace TestProject1
{
    public class Tests
    {      
        public void TestMethod1_Last_Value()
        {
            ArrayReorganization test = new ArrayReorganization();
            test.AssembleArrays();          
            var expectedLastValue = -7;
            Assert.AreEqual(expectedLastValue, test.Array2[9], 0.001,"Last value of Array2 should be -7");
        }

        public void TestMethod2_Last_Value()
        {
            ArrayReorganization test = new ArrayReorganization();
            test.AssembleArrays();
            var expectedLastValue = -7;
            Assert.AreNotEqual(expectedLastValue, test.myArray[9], "Last value of Array1 should definetely not be -7");
        }

        public void TestMethod3_Equal_Other_Values()
        {
            ArrayReorganization test = new ArrayReorganization();
            test.AssembleArrays();
            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(test.myArray[i], test.Array2[i], 0.001, "All values except last value should be equal in both arrays");
            }
        }

    }
}