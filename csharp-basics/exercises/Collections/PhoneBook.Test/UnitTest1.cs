using NUnit.Framework;

namespace PhoneBook.Test
{
    public class Tests
    {
        PhoneDirectory _phoneDirectory;

        [SetUp]
        public void Setup()
        {
            //Arrange and Act
            _phoneDirectory = new PhoneDirectory();
            _phoneDirectory.PutNumber("AlexanderV", "+371 2834567");
            _phoneDirectory.PutNumber("A", "+371 28345a67");
            _phoneDirectory.PutNumber("Vincent", "+371 28434567");
            _phoneDirectory.PutNumber("Tarantino", "+371 28345646");
            _phoneDirectory.PutNumber("Mr. Jecabson", "+371 28345679");
        }

        [Test]
        public void PhoneDirectory_CheckSavedEntries_ConstructorDataEqualToInputData()
        {
            //Assert
            Assert.AreEqual(_phoneDirectory.GetEntryCount(), 5, "5 entries have been made");
            Assert.AreEqual(_phoneDirectory.GetNumber("Mr. Jecabson"), "+371 28345679", "Number of entry has not been returned");
            Assert.AreEqual(_phoneDirectory.GetNumber("A"), "+371 28345a67", "Number of entry has not been returned");
            Assert.AreEqual(_phoneDirectory. GetNumber("A"), "+371 28345a67", "Number of entry has not been returned");
        }

        [Test]
        public void PhoneDirectory_PutTheSameNameAgain_TheSameDataIsNotSaved()
        {
            //Act
            _phoneDirectory.PutNumber("Mr. Jecabson", "+371 28345679");

            //Assert
            Assert.AreEqual(_phoneDirectory.GetNumber("Mr. Jecabson"), "+371 28345679", "The same name is not saved");          
        }

        [Test]
        public void PhoneDirectory_PutTheSameNameWithNewNumber_NewNumberShouldBeSavedUnderThisName()
        {
            //Act
            _phoneDirectory.PutNumber("Mr. Jecabson", "666");

            //Assert
            Assert.AreEqual(_phoneDirectory.GetNumber("Mr. Jecabson"), "666", "The same name has changed number. Log was not saved.");
        }
    }
}