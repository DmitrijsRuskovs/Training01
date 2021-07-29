using NUnit.Framework;
using ArrayX6;

namespace TestProject1
{
    public class Tests
    {
        //private ArrayReorganization _target;
       
        public Tests()
        {         
        }

        [SetUp]
        public void Setup()
        {           
        }

        [Test]
        public void AssembleArrays_ArrayValuesAreEqualExceptLast_1()
        {
            ArrayReorganization _target = new ArrayReorganization();
            _target.AssembleArrays();
            var expectedLastValue = -7;
            Assert.AreEqual(expectedLastValue, _target.myArray[9], 0.001,"Last value of Array2 should be -7");
        }

        [Test]
        public void AssembleArrays_ArrayValuesAreEqualExceptLast_2()
        {
            ArrayReorganization _target = new ArrayReorganization();
            _target.AssembleArrays();
            var expectedLastValue = -7;
            Assert.AreNotEqual(expectedLastValue, _target.Array2[9], "Last value of Array1 should definetely not be -7");
        }

        [Test]
        public void AssembleArrays_ArrayValuesAreEqualExceptLast_3()
        {
            ArrayReorganization _target = new ArrayReorganization();
            _target.AssembleArrays();
            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(_target.myArray[i], _target.Array2[i], 0.001, "All values except last value should be equal in both arrays");
            }
        }
    }
}