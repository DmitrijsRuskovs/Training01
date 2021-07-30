using NUnit.Framework;
using System.Collections.Generic;
using WordCount;

namespace WordCount.Test
{
    public class Tests
    {
        private string _expected;
        Dictionary<string, int> _result;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WordCount_WordCountTextOf6WordsAndApostroph()
        {
            _result = WordCount.Program.textAttributes("That's just a first test!");         
            Assert.AreEqual(_result["Words"], 6, "That's just a first test! :: contains 6 words");
            Assert.AreEqual(_result["Lines"], 1, "That's just a first test! :: contains 1 line");
            Assert.AreEqual(_result["Total Characters"], 25, "That's just a first test! :: contains 40 characters total");
            Assert.AreEqual(_result["Letter and Digit characters"], 19, "That's just a first test! :: contains 30 text characters");
        }

        [Test]
        public void WordCount_TextOf3Lines()
        {
            _result = WordCount.Program.textAttributes("Line1\nLine2\nLine3");
            Assert.AreEqual(_result["Words"], 3, "Line1\nLine2\nLine3 :: contains 3 words");
            Assert.AreEqual(_result["Lines"], 3, "Line1\nLine2\nLine3 :: contains 3 line");
            Assert.AreEqual(_result["Total Characters"], 17, "Line1\nLine2\nLine3 :: contains 17 characters total");
            Assert.AreEqual(_result["Letter and Digit characters"], 15, "Line1\nLine2\nLine3 :: contains 15 text characters");
        }

        [Test]
        public void WordCount_TextOfSmallWords()
        {
            _result = WordCount.Program.textAttributes("1 2 3 4 5 6 A B C, D! A. B C?");
            Assert.AreEqual(_result["Words"], 13, "1 2 3 4 5 6 A B C, D! A. B C? :: contains 13 words");
            Assert.AreEqual(_result["Lines"], 1, "1 2 3 4 5 6 A B C, D! A. B C? :: contains 1 line");
            Assert.AreEqual(_result["Total Characters"], 29, "1 2 3 4 5 6 A B C, D! A. B C? :: contains 29 characters total");
            Assert.AreEqual(_result["Letter and Digit characters"], 13, "1 2 3 4 5 6 A B C, D! A. B C? :: contains 13 text characters");
        }
    }
}