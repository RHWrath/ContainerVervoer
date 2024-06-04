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


    //[TestMethod]
    //public void FailedContainerWeightValidation()
    //{    

    //    //act
    //    ArgumentException Underlimit = Assert.ThrowsException<ArgumentException>( () => new Container(true, true, 1));
    //    ArgumentException Overimit = Assert.ThrowsException<ArgumentException>(() => new Container(true, true, 31));


    //    //assert
    //    Assert.AreEqual("Error invalid weight", Underlimit.Message);
    //    Assert.AreEqual("Error invalid weight", Overimit.Message);

    //}




}
