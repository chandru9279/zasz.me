using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zasz.me.Services;

namespace zasz.health.ServiceTests
{
    [TestClass]
    public class TagCloudServiceTests
    {
// ReSharper disable InconsistentNaming
        private readonly Func<int, int, PointF> P = (A, B) => new PointF(A, B);
        private readonly Func<PointF, SizeF, RectangleF> R = (A, B) => new RectangleF(A, B);
        private readonly Func<int, int, SizeF> S = (A, B) => new SizeF(A, B);

        private readonly TagCloudService _Service = new TagCloudService(new Dictionary<string, int>
                                                                            {
                                                                                {"asp.net", 15},
                                                                                {"games", 10},
                                                                                {"fun", 18},
                                                                                {"books", 5},
                                                                                {"music", 9},
                                                                                {"crapo", 1},
                                                                                {"dota", 2},
                                                                            });

// ReSharper restore InconsistentNaming

        [TestMethod]
        public void TestTryPointFailsOnCollision()
        {
            _Service._Occupied.Add(R(P(3, 0), S(1, 2)));
            Assert.IsFalse(_Service.TryPoint(P(2, 1), S(2, 1)));
            Assert.IsTrue(_Service.TryPoint(P(2, 2), S(2, 1)));

            _Service._Occupied.Add(R(P(0, 0), S(3, 3)));
            Assert.IsTrue(_Service.TryPoint(P(3, 2), S(1, 2)));
            Assert.IsTrue(_Service.TryPoint(P(0, 3), S(4, 1)));
            Assert.IsFalse(_Service.TryPoint(P(1, 1), S(1, 1)));
        }

        [TestMethod]
        public void TestGetNextPointInSpiral()
        {
            Assert.AreEqual(P(3, 2), _Service.GetSpiralNext(P(2, 2)));
            Assert.AreEqual(P(3, 3), _Service.GetSpiralNext(P(3, 2)));
            Assert.AreEqual(P(1, 3), _Service.GetSpiralNext(P(3, 3)));
            Assert.AreEqual(P(1, 1), _Service.GetSpiralNext(P(1, 3)));
            Assert.AreEqual(P(4, 1), _Service.GetSpiralNext(P(1, 1)));
            Assert.AreEqual(P(4, 4), _Service.GetSpiralNext(P(4, 1)));
            Assert.AreEqual(P(0, 4), _Service.GetSpiralNext(P(4, 4)));
            Assert.AreEqual(P(0, 0), _Service.GetSpiralNext(P(0, 4)));
            Assert.AreEqual(P(5, 0), _Service.GetSpiralNext(P(0, 0)));
        }
    }
}