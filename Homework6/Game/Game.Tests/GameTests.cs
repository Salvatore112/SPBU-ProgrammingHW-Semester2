using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameSpace.Tests;

public class Tests
{
    [Test]
    public void GoingRightShouldWork()
    {
        var mapAndMovement = new MapAndMovement();
        mapAndMovement.UploadMap("testMap1.txt");
        mapAndMovement.PerformMove(1, 0);
        Assert.That(mapAndMovement.Map[1, 1] == ' ' && mapAndMovement.Map[1, 2] == '@');
    }
    
    [Test]
    public void GoingLeftShouldWork()
    {
        var mapAndMovement = new MapAndMovement();
        mapAndMovement.UploadMap("testMap1.txt");
        mapAndMovement.PerformMove(1, 0);
        mapAndMovement.PerformMove(1, 0);
        mapAndMovement.PerformMove(-1, 0);
        Assert.That(mapAndMovement.Map[1, 1] == ' ' && mapAndMovement.Map[1, 2] == '@');
    }

    [Test]
    public void GoingDownShouldWork()
    {
        var mapAndMovement = new MapAndMovement();
        mapAndMovement.UploadMap("testMap1.txt");
        mapAndMovement.PerformMove(0, 1);
        Assert.That(mapAndMovement.Map[1, 1] == ' ' && mapAndMovement.Map[2, 1] == '@');
    }

    [Test]
    public void GoingUpShouldWork()
    {
        var mapAndMovement = new MapAndMovement();
        mapAndMovement.UploadMap("testMap1.txt");
        mapAndMovement.PerformMove(0, 1);
        mapAndMovement.PerformMove(0, 1);
        mapAndMovement.PerformMove(0, -1);
        Assert.That(mapAndMovement.Map[1, 1] == ' ' && mapAndMovement.Map[2, 1] == '@');
    }
}