using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.GameEngine
{
    [TestFixture]
    public class HelperEngineUnitTests
    {
        private const int ERROR_RESULT = 0;
        [Test]
        // This function ensures that Roll 1 and Dice 10 
        // are acceptable parameters for method RollDice
        public void RollDice_Roll_1_Dice_10_Should_Pass()
        {
            // Arrange
            var Roll = 1;
            var Dice = 10;
            var Expected = 1;

            // Getting actual results
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);

            // Assert
            //Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);

            // Roll 1 Dice 10 should pass
            //Assert.Pass(TestContext.CurrentContext.Test.Name);

            Assert.NotZero(Actual, TestContext.CurrentContext.Test.Name);
        }

        // This function ensures that Roll 2 and Dice 10 
        // are acceptable parameters for method RollDice
        [Test]
        public void RollDice_Roll_2_Dice_10_Should_Pass()
        {
            var Roll = 2;
            var Dice = 10;
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);
            Assert.NotZero(Actual, TestContext.CurrentContext.Test.Name);
        }
        [Test]

        // This function ensures that Roll 0 and Dice 10 
        // are not acceptable parameters for method RollDice
        // Result should be 0 because Roll can't be < 1
        public void RollDice_Roll_0_Dice_10_Should_Fail()
        {
            var Roll = 0;
            var Dice = 10;
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);
            var Expected = ERROR_RESULT;
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }
        [Test]
        // This function ensures that Roll -1 and Dice 10 
        // are not acceptable parameters for method RollDice
        // Result should be 0 because Roll can't be < 1
        public void RollDice_Roll_Neg1_Dice_10_Should_Fail()
        {
            var Roll = -1;
            var Dice = 10;
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);
            var Expected = ERROR_RESULT;
            
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }
        [Test]

        // This function ensures that Roll 1 and Dice -1 
        // are not acceptable parameters for method RollDice
        // Result should be 0 because Dice can't be <1
        public void RollDice_Roll_1_Dice_Neg1_Should_Fail()
        {
            var Roll = 1;
            var Dice = -1;
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);
            var Expected = ERROR_RESULT;

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        // This function ensures that Roll 1 and Dice 0
        // are not acceptable parameters for method RollDice
        // Result should be 0 because Dice can't be <1
        public void RollDice_Roll_1_Dice_0_Should_Fail()
        {
            var Roll = 1;
            var Dice = 0;
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);
            var Expected = ERROR_RESULT;

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }



    }
}
