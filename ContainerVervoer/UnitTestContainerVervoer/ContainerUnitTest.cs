using ContainerVervoer.Classes;

namespace UnitTestContainerVervoer;

[TestClass]
public class ContainerUnitTest
{
    [TestMethod]
    public void AcceptedContainerWeightValidation()
    {
        //Arrange
        Container container = new Container(true, true, 25);


        //act
        bool succes = container.AcceptedWeight();


        //assert
        Assert.AreEqual(true, succes);
    }


    [TestMethod]
    public void FailedContainerWeightValidation()
    {
        //Arrange
        Container container = new Container(true, true, 1);


        //act
        bool succes = container.AcceptedWeight();


        //assert
        Assert.AreEqual(false, succes);
    }




}
