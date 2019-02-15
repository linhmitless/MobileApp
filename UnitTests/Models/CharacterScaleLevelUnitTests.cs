using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This program tests the Scale Level method inside Character
// Naming convention for unit tests: <Class>_<Method> _<Scenario>_<Condition> _<Expected>
namespace UnitTests.Models
{
    [TestFixture]
    public class CharacterScaleLevelUnitTests
    {
        [Test]

        // This test ensures that given a level smaller than allowed (1-20)
        // it would return false
        public void Character_ScaleLevel_Level_0_Should_Fail()
        {
            var Level = 0;
            bool Expected = false;
            //Mock<CharacterScaleLevelUnitTests> Test1 = new Mock<CharacterScaleLevelUnitTests>();

            // Because ScaleLevel is non-static, requires object
            Crawl.Models.Character TestChar = new Crawl.Models.Character();
            bool Actual = TestChar.ScaleLevel(Level);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }
        [Test]
        // This test ensures that given a level smaller than allowed (1-20)
        // it would return false
        public void Character_ScaleLevel_Level_Neg1_Should_Fail()
        {
            var Level = -1;
            bool Expected = false;
           
            // Because ScaleLevel is non-static, requires object
            Crawl.Models.Character TestChar = new Crawl.Models.Character();
            bool Actual = TestChar.ScaleLevel(Level);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }
        [Test]
        // This test ensure that level 1 is allowed
        public void Character_ScaleLevel_Level_1_Should_Pass()
        {

            // Because ScaleLevel is non-static, requires object
            Crawl.Models.Character TestChar = new Crawl.Models.Character();
            // Setting object's state before calling method
            var Level = 1;
            bool Expected = true;
            var OldHealth = TestChar.Attribute.MaxHealth;


            bool Actual = TestChar.ScaleLevel(Level);

            // States after calling method

            var NewHealth = TestChar.Attribute.MaxHealth;

            // Assert that the method runs and returns true
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
            // Assert that the max health has changed
            Assert.AreNotEqual(OldHealth, NewHealth, TestContext.CurrentContext.Test.Name);

        }

        [Test]
        // This test ensure that method allows levelling up from 19 to 20
        public void Character_ScaleLevel_Level_20_Should_Pass()
        {

            // Because ScaleLevel is non-static, requires object
            Crawl.Models.Character TestChar = new Crawl.Models.Character();
            // Setting object's state before calling method

            TestChar.Level = 19; //Current is 19
            var NewLevel = TestChar.Level + 1;
            var OldHealth = TestChar.Attribute.MaxHealth;

            // States after calling method
            bool Expected = true;
            bool Actual = TestChar.ScaleLevel(NewLevel);
            var NewHealth = TestChar.Attribute.MaxHealth;

            // Assert that the method runs and returns true
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
            // Assert that the max health has changed
            Assert.AreNotEqual(OldHealth, NewHealth, TestContext.CurrentContext.Test.Name);

        }

        [Test]
        // This test ensures method doesn't allow levelling up from 20 to 21
        public void Character_ScaleLevel_Level_21_Should_Fail()
        {


            // Because ScaleLevel is non-static, requires object
            Crawl.Models.Character TestChar = new Crawl.Models.Character();
            // Setting object's state before calling method
            TestChar.Level = 20;
            var NewLevel = TestChar.Level + 1;


            // States after calling method
            bool Expected = false;
            bool Actual = TestChar.ScaleLevel(NewLevel);

            // Assert that the method runs and returns true
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        // This method ensures that the passed in level can't be 
        // smaller than current level
        public void Character_ScaleLevel_New_Smaller_Current_Should_Fail()
        {


            // Because ScaleLevel is non-static, requires object

            Crawl.Models.Character TestChar = new Crawl.Models.Character();
            TestChar.Level = 11;
            var NewLevel = 10;
            bool Expected = false;
            bool Actual = TestChar.ScaleLevel(NewLevel);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        // This method ensures that passed in level can't be equal to 
        // current level
        public void Character_ScaleLevel_New_Equal_Current_Should_Fail()
        {

            // Because ScaleLevel is non-static, requires object

            Crawl.Models.Character TestChar = new Crawl.Models.Character();
            TestChar.Level = 11;
            var NewLevel = TestChar.Level;
            bool Expected = false;
            bool Actual = TestChar.ScaleLevel(NewLevel);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        // This method ensures that if passed in level is larger than current level, 
        // it should pass
        public void Character_ScaleLevel_New_Larger_Current_Should_Pass()
        {

            // Because ScaleLevel is non-static, requires object
            Crawl.Models.Character TestChar = new Crawl.Models.Character();
            // Setting object's state before calling method
            TestChar.Level = 11;
            var NewLevel = TestChar.Level + 1;
            var OldHealth = TestChar.Attribute.MaxHealth;

            // States after calling method
            bool Expected = true;
            bool Actual = TestChar.ScaleLevel(NewLevel);
            var NewHealth = TestChar.Attribute.MaxHealth;

            // Assert that the method runs and returns true
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
            // Assert that the max health has changed
            Assert.AreNotEqual(OldHealth, NewHealth, TestContext.CurrentContext.Test.Name);
        }
        [Test]
        // This method ensures that Scale Level works correctly 
        // by calling a fixed RollDice with Level 10 given
        // and checking if new Max Health is updated as expected
        public void Character_ScaleLevel_Level_10_Should_Increase_Health()
        {

            // Because ScaleLevel is non-static, requires object
            Crawl.Models.Character TestChar = new Crawl.Models.Character();
            
            // Setting object's state before calling method
            TestChar.Level = 9;
            var NewLevel = TestChar.Level + 1;
            

            var Dice = 10;
            // Setting flag to forced non-random rolls
            // So we can know exactly how much RollDice would return
            Crawl.Models.GameGlobals.ForceRollsToNotRandom = true;

            // Getting value from Roll Rice
            var ExpectedRollDice = Crawl.GameEngine.HelperEngine.RollDice(NewLevel, Dice);

            // Calling Scale Level
            var Actual = TestChar.ScaleLevel(NewLevel);
            // Getting MaxHealth after ScaleLevel has been called
            var NewHealth = TestChar.Attribute.MaxHealth;


            // Assert to compare the increase in health with the variable returned 
            // by RollDice(10,10)
            Assert.AreEqual(NewHealth, ExpectedRollDice, TestContext.CurrentContext.Test.Name);


            // Reverting the state change back to before test
            Crawl.Models.GameGlobals.ForceRollsToNotRandom = false;
        }
    }
}
