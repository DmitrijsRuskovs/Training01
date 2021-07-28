using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ArrayX6;



namespace Exercise6.Test
{
    [TestClass]
    public class UnitTest1
    {
        private ArrayExe _newProgram;
            [TestMethod]
        public void TestMethod1()
        {
            Program program1 = new Program();
            var expectedLastValue = -7;
            Assert.AreEqual(expectedLastValue, Program. Array2[arraySize - 1]);
        }
    }
}
