using ContainerVervoer.Classes;

namespace UnitTestContainerVervoer;

[TestClass]
public class ShipUnitTest
{
    [TestMethod]
    public void MarginTest()
    {
        //Arrange
        Ship TestShip = new Ship(3, 3);


        //act
        bool succes = TestShip.CalculateMargins(100,100);


        //assert
        Assert.AreEqual(true, succes);
    }


    
    
}
