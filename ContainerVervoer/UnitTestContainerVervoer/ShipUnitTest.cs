using ContainerVervoer.Classes;

namespace UnitTestContainerVervoer;

[TestClass]
public class ShipUnitTest
{

    private Container DefaultLightContainer { get; } = new Container(false, false, 5);
    private Container DefaultMediumContainer { get; } = new Container(false, false, 15);
    private Container DefaultHeavyContainer { get; } = new Container(false, false, 30);
    private Ship DefaultShip { get; } = new Ship(3, 3);


    [TestMethod]
    public void AcceptedMarginTest()
    {
        //Arrange
        Ship TestShip = new Ship(3, 3);


        //act
        bool succes = TestShip.CalculateMargins(100,100);


        //assert
        Assert.AreEqual(true, succes);
    }

    [TestMethod]
    public void FailedMarginTest()
    {
        //Arrange
        Ship TestShip = new Ship(3, 3);


        //act
        bool succes = TestShip.CalculateMargins(70, 100);


        //assert
        Assert.AreEqual(false, succes);
    }

    [TestMethod]
    public void FailedMarginTestWithMinus()
    {
        //Arrange
        Ship TestShip = new Ship(3, 3);


        //act
        bool succes = TestShip.CalculateMargins(-1, 100);


        //assert
        Assert.AreEqual(false, succes);
    }

    [TestMethod]
    public void AddingOneContainerToDock()
    {
        //Arrange
        int Counter;

        //Act
        DefaultShip.AddContainerToDock(DefaultMediumContainer);
        Counter = DefaultShip.onDock.Count();
        //Assert
        Assert.AreEqual(1, Counter); 
    }

    [TestMethod]
    public void AddingSeveralContainerToDock()
    {
        //Arrange
        int Counter;

        //Act
        DefaultShip.AddContainerToDock(DefaultMediumContainer);
        DefaultShip.AddContainerToDock(DefaultLightContainer);
        DefaultShip.AddContainerToDock(DefaultHeavyContainer);
        DefaultShip.AddContainerToDock(DefaultMediumContainer);
        DefaultShip.AddContainerToDock(DefaultLightContainer);
        DefaultShip.AddContainerToDock(DefaultMediumContainer);
        DefaultShip.AddContainerToDock(DefaultMediumContainer);

        Counter = DefaultShip.onDock.Count();
        //Assert
        Assert.AreEqual(7, Counter);
    }






}
