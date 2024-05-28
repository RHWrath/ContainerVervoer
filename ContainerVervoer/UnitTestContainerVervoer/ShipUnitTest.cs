using ContainerVervoer.Classes;

namespace UnitTestContainerVervoer;

[TestClass]
public class ShipUnitTest
{
    #region Presets
    private Container DefaultLightContainer { get; } = new Container(false, false, 5);
    private Container DefaultMediumContainer { get; } = new Container(false, false, 15);
    private Container DefaultHeavyContainer { get; } = new Container(false, false, 30);

    private Container CooledLightContainer { get; } = new Container(true, false, 5);
    private Container CooledMediumContainer { get; } = new Container(true, false, 15);
    private Container CooledHeavyContainer { get; } = new Container(true, false, 30);

    private Container ValuedLightContainer { get; } = new Container(false, true, 5);
    private Container ValuedMediumContainer { get; } = new Container(false, true, 15);
    private Container ValuedHeavyContainer { get; } = new Container(false, true, 30);

    private Container ValuedCooledLightContainer { get; } = new Container(true, true, 5);
    private Container ValuedCooledMediumContainer { get; } = new Container(true, true, 15);
    private Container ValuedCooledHeavyContainer { get; } = new Container(true, true, 30);
    private Ship DefaultShip { get; } = new Ship(3, 3);
    #endregion

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

    [TestMethod]
    public void SortingMultipleContainers()
    {
        //Arrange
        List<Container> containers = new List<Container>()
        {
            new Container(false, false, 5),
            new Container(true, false, 5),
            new Container(true, true, 5),
            new Container(false, true, 5)        
        };
        Ship ship = new Ship(2, 2);
        

        //Act
        containers = ship.SortContainer(containers);

        //Assert
        Assert.AreEqual(true, containers.ElementAt(0).IsCooled);
        Assert.AreEqual(false, containers.ElementAt(0).IsValueble);

        Assert.AreEqual(true, containers.ElementAt(1).IsCooled);
        Assert.AreEqual(true, containers.ElementAt(1).IsValueble);

        Assert.AreEqual(false, containers.ElementAt(2).IsCooled);
        Assert.AreEqual(false, containers.ElementAt(2).IsValueble);

        Assert.AreEqual(false, containers.ElementAt(3).IsCooled);
        Assert.AreEqual(true, containers.ElementAt(3).IsValueble);
    }

    [TestMethod]
    public void CalculateLeftSide()
    {
        //Arrange
        DefaultShip.AddContainerToDock(DefaultLightContainer); //left
        DefaultShip.AddContainerToDock(DefaultLightContainer); //right
        DefaultShip.AddContainerToDock(DefaultLightContainer); //left
        DefaultShip.AddContainerToDock(DefaultLightContainer); //right
        //Act
        //Assert
    }
    [TestMethod]
    public void CalculateRightSide()
    {
        //Arrange
        DefaultShip.AddContainerToDock(DefaultLightContainer); //left
        DefaultShip.AddContainerToDock(DefaultLightContainer); //right
        DefaultShip.AddContainerToDock(DefaultLightContainer); //left
        DefaultShip.AddContainerToDock(DefaultLightContainer); //right
        //Act
        //Assert
    }




}
