namespace RoutesTaskSpace.Tests;

public class Tests
{
    private static IEnumerable<TestCaseData> Prim
      => new TestCaseData[]
      {
            new TestCaseData(new Prim())
      };

    [TestCaseSource(nameof(Prim))]
    public void AlgorithmShouldBeAbleToDetermineWhetherATreeIsConnected(Prim prim)
    {
        prim.BuildMaxSpanningTree("notConnected.txt");
        prim.IsConnected();
        Assert.That(!prim.Connected);
    }

    [TestCaseSource(nameof(Prim))]
    public void AlgorithmShouldWorkOnAnExampleTest(Prim prim)
    {
        prim.BuildMaxSpanningTree("exampleTest.txt");
        Assert.That(prim.OutputEdges[0].Length + prim.OutputEdges[1].Length == 15);
    }
}