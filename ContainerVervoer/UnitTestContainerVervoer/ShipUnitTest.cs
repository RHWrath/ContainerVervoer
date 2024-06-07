using ContainerVervoer.Classes;

namespace UnitTestContainerVervoer;

[TestClass]
public class ShipUnitTest
{
    #region Presets
    //LDC = LightDefaultContainer - MDC = MediumDefaultContainer - HDC = HeavyDefaultContainer
    private Container LDC { get; } = new Container(false, false, 5);
    private Container MDC { get; } = new Container(false, false, 15);
    private Container HDC { get; } = new Container(false, false, 30);

    // LCC = LightCooledContainer - MCC = MediumCooledContainer - HCC = HeavyCooledContainer
    private Container LCC { get; } = new Container(true, false, 5);
    private Container MCC { get; } = new Container(true, false, 15);
    private Container HCC { get; } = new Container(true, false, 30);

    //LVC = LightValuedContainer - MVC = MediumValuedContainer - HVC = HeavyValuedContainer
    private Container LVC { get; } = new Container(false, true, 5);
    private Container MVC { get; } = new Container(false, true, 15);
    private Container HVC { get; } = new Container(false, true, 30);

    //LVCC = LightValuedCooledContainer - MVCC = MediumValuedCooledContainer - HVCC = HeavyValuedCooledContainer
    private Container LVCC { get; } = new Container(true, true, 5);
    private Container MVCC { get; } = new Container(true, true, 15);
    private Container HVCC { get; } = new Container(true, true, 30);
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
        Ship Testship = new Ship(3, 3);

        //Act
        Testship.AddContainerToDock(MDC);
        Counter = Testship.onDock.Count();
        //Assert
        Assert.AreEqual(1, Counter);
    }

    [TestMethod]
    public void AddingSeveralContainerToDock()
    {
        //Arrange
        int Counter;
        Ship Testship = new Ship(3, 3);

        //Act
        Testship.AddContainerToDock(MDC);
        Testship.AddContainerToDock(LDC);
        Testship.AddContainerToDock(HDC);
        Testship.AddContainerToDock(MDC);
        Testship.AddContainerToDock(LDC);
        Testship.AddContainerToDock(MDC);
        Testship.AddContainerToDock(MDC);

        Counter = Testship.onDock.Count();
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
            new Container(true, false, 5),        
            new Container(false, true, 5)
        };
        Ship ship = new Ship(2, 2);
        

        //Act
        containers = ship.SortContainer(containers);

        //Assert
        Assert.AreEqual(true, containers.ElementAt(0).IsCooled);
        Assert.AreEqual(false, containers.ElementAt(0).IsValueble);

        Assert.AreEqual(true, containers.ElementAt(1).IsCooled);
        Assert.AreEqual(false, containers.ElementAt(1).IsValueble);

        Assert.AreEqual(true, containers.ElementAt(2).IsCooled);
        Assert.AreEqual(true, containers.ElementAt(2).IsValueble);

        Assert.AreEqual(false, containers.ElementAt(3).IsCooled);
        Assert.AreEqual(false, containers.ElementAt(3).IsValueble);

        Assert.AreEqual(false, containers.ElementAt(4).IsCooled);
        Assert.AreEqual(true, containers.ElementAt(4).IsValueble);
    }

    [TestMethod]
    public void DivideContainersOverShip()
    {
        //Arrange
        Ship testShip = new Ship (2, 2);
        testShip.AddContainerToDock(HCC); //30
        testShip.AddContainerToDock(HCC); //30
        testShip.AddContainerToDock(HCC); //30
        testShip.AddContainerToDock(HVCC); //30
        testShip.AddContainerToDock(HCC); //30
        testShip.AddContainerToDock(HCC); //30
        testShip.AddContainerToDock(HDC); //30
        testShip.AddContainerToDock(HDC); //30
        testShip.AddContainerToDock(HDC); //30
        testShip.AddContainerToDock(HDC); //30
        testShip.AddContainerToDock(HDC); //30


        //Act
        testShip.DivideContainersOverShip();
        //Assert
        Assert.AreEqual(true, testShip.ContainerStackRows[0].ContainerStacks[0].Containers[0].IsCooled);
        Assert.AreEqual(false, testShip.ContainerStackRows[0].ContainerStacks[0].Containers[0].IsValueble);
        Assert.AreEqual(30, testShip.ContainerStackRows[0].ContainerStacks[0].Containers[0].CurrentContainerWeight);

    }

    [TestMethod]
    public void InvalidWeightWhenDivideContainersOverShip()
    {
        //Arrange
        Ship testShip = new Ship(2, 2);
        testShip.AddContainerToDock(HCC);
        testShip.AddContainerToDock(HVCC);
        testShip.AddContainerToDock(HCC);


        //Act
        ArgumentException ErrorMessage = Assert.ThrowsException<ArgumentException>(() => testShip.DivideContainersOverShip());
        
        //Assert
        Assert.AreEqual("Error Ship weight invalid", ErrorMessage.Message);
    }
}
