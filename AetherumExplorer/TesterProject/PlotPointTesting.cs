using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TwilightShards.genLibrary;

namespace TwilightShards.TesterProject
{
    [TestClass]
    public class PlotPointUnderTest
    {
        [TestMethod]
        public void PlotPointTesting()
        {
            //routine test of get accessors
            PlotPoint p = new PlotPoint(-2, 2, 1);
            Assert.AreEqual<int>(-2, p.GetCoordX());
            Assert.AreEqual<int>(2, p.GetCoordY());
            Assert.AreEqual<int>(1, p.GetCoordZ());

            //testing equals operator
            PlotPoint q = new PlotPoint(-2, 2, 1);
            PlotPoint o = new PlotPoint(2, -2, 0);
            Assert.AreEqual(p, q);
            Assert.AreNotEqual(p, o);
            Assert.AreNotSame(p, o);

            //now to test distance functionality
            PlotPoint r = new PlotPoint(3, 4, 5);
            PlotPoint s = new PlotPoint(-7, 10, 12);
            PlotPoint t = new PlotPoint(0, 0, 0);
            PlotPoint u = new PlotPoint(2, 6, 7);

            //distance first
            Assert.AreEqual(Math.Sqrt(185), r.GetDistance(s));
            Assert.AreEqual(Math.Sqrt(50), r.GetDistance(t));
            Assert.AreEqual(3, r.GetDistance(u));
        }
    }
}
