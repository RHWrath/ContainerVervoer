using ContainerVervoer.Classes;


namespace UnitTestContainerVervoer
{
    [TestClass]
    public class ContainerStackRowTests
    {
        [TestMethod]
        public void TestDivideWidth()
        {
            //Arrange
            Ship ShipOneByOne = new(1, 1);
            Ship ShipTwoByTwo = new(2, 2);
            Ship ShipThreeByThree = new(3, 3);
            Ship ShipFourByFour = new(4, 4);
            Ship ShipFiveByFive = new(5, 5);
            Ship ShipSixBySix = new(6, 6);
            Ship ShipSevenBySeven = new(7, 7);

            //Assert
            Assert.AreEqual(0, ShipOneByOne.ContainerStackRows[0].DivideWidth);
            Assert.AreEqual(1, ShipTwoByTwo.ContainerStackRows[0].DivideWidth);
            Assert.AreEqual(1, ShipThreeByThree.ContainerStackRows[0].DivideWidth);
            Assert.AreEqual(2, ShipFourByFour.ContainerStackRows[0].DivideWidth);
            Assert.AreEqual(2, ShipFiveByFive.ContainerStackRows[0].DivideWidth);
            Assert.AreEqual(3, ShipSixBySix.ContainerStackRows[0].DivideWidth);
            Assert.AreEqual(3, ShipSevenBySeven.ContainerStackRows[0].DivideWidth);
        }
    }
}
