using System.Data;
using System.Linq.Expressions;

namespace GameSpace.Tests;

public class Tests
{
    [Test]
    public void GoingRightShouldWork()
    {
        var mapAndMovement = new MapAndMovement();
        mapAndMovement.LoadMap("testMap1.txt");
        mapAndMovement.PerformMove(1, 0);
        Assert.That(mapAndMovement.Map[1, 1], Is.EqualTo(' '));
        Assert.That(mapAndMovement.Map[1, 2], Is.EqualTo('@'));
    }
    
    [Test]
    public void GoingLeftShouldWork()
    {
        var mapAndMovement = new MapAndMovement();
        mapAndMovement.LoadMap("testMap1.txt");
        mapAndMovement.PerformMove(1, 0);
        mapAndMovement.PerformMove(1, 0);
        mapAndMovement.PerformMove(-1, 0);
        Assert.That(mapAndMovement.Map[1, 1], Is.EqualTo(' '));
        Assert.That(mapAndMovement.Map[1, 2], Is.EqualTo('@'));
    }

    [Test]
    public void GoingDownShouldWork()
    {
        var mapAndMovement = new MapAndMovement();
        mapAndMovement.LoadMap("testMap1.txt");
        mapAndMovement.PerformMove(0, 1);
        Assert.That(mapAndMovement.Map[1, 1], Is.EqualTo(' '));
        Assert.That(mapAndMovement.Map[2, 1], Is.EqualTo('@'));
    }

    [Test]
    public void GoingUpShouldWork()
    {
        var mapAndMovement = new MapAndMovement();
        mapAndMovement.LoadMap("testMap1.txt");
        mapAndMovement.PerformMove(0, 1);
        mapAndMovement.PerformMove(0, 1);
        mapAndMovement.PerformMove(0, -1);
        Assert.That(mapAndMovement.Map[1, 1], Is.EqualTo(' '));
        Assert.That(mapAndMovement.Map[2, 1], Is.EqualTo('@'));
    }

    [Test]
    public void ExceptionShouldBeThrownWhenTryingToLoadAMapWithNoCharacter()
    {
        var mapAndMovement = new MapAndMovement();
        
        Assert.Throws<InvalidMapException>(() => mapAndMovement.LoadMap("noCharacterMap.txt"));
    }
}