using System;
using System.Collections.Generic;
using System.Drawing;
using Xunit;
using zasz.me.Services.TagCloud;

namespace zasz.health.ServiceTests
{
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
                                                                            }, 300, 300);

// ReSharper restore InconsistentNaming

        [Fact]
        public void TestTryPointFailsOnCollision()
        {
            _Service._Occupied.Add(R(P(3, 0), S(1, 2)));
            Assert.False(_Service.TryPoint(P(2, 1), S(2, 1)));
            Assert.True(_Service.TryPoint(P(2, 2), S(2, 1)));

            _Service._Occupied.Add(R(P(0, 0), S(3, 3)));
            Assert.True(_Service.TryPoint(P(3, 2), S(1, 2)));
            Assert.True(_Service.TryPoint(P(0, 3), S(4, 1)));
            Assert.False(_Service.TryPoint(P(1, 1), S(1, 1)));
        }

        [Fact]
        public void TestGetNextPointInSpiral()
        {
            _Service._CurrentEdgeSize = 1;
            _Service._SleepingEdge = true;

            Assert.Equal(P(3, 2), _Service.GetSpiralNext(P(2, 2)));
            Assert.Equal(P(3, 3), _Service.GetSpiralNext(P(3, 2)));
            Assert.Equal(P(1, 3), _Service.GetSpiralNext(P(3, 3)));
            Assert.Equal(P(1, 1), _Service.GetSpiralNext(P(1, 3)));
            Assert.Equal(P(4, 1), _Service.GetSpiralNext(P(1, 1)));
            Assert.Equal(P(4, 4), _Service.GetSpiralNext(P(4, 1)));
            Assert.Equal(P(0, 4), _Service.GetSpiralNext(P(4, 4)));
            Assert.Equal(P(0, 0), _Service.GetSpiralNext(P(0, 4)));
            Assert.Equal(P(5, 0), _Service.GetSpiralNext(P(0, 0)));
        }
        
        
        [Fact]
        public void TestGetNextPointInEdge()
        {
            _Service._CurrentEdgeSize = 1;
            _Service._SleepingEdge = true;
            _Service._CurrentCorner = P(2, 2);
            _Service._Center = P(2, 2);

            Assert.Equal(P(3, 2), _Service.GetNextPointInEdge(P(2, 2)));

            Assert.Equal(P(3, 3), _Service.GetNextPointInEdge(P(3, 2)));

            Assert.Equal(P(2, 3), _Service.GetNextPointInEdge(P(3, 3)));
            Assert.Equal(P(1, 3), _Service.GetNextPointInEdge(P(2, 3)));

            Assert.Equal(P(1, 2), _Service.GetNextPointInEdge(P(1, 3)));
            Assert.Equal(P(1, 1), _Service.GetNextPointInEdge(P(1, 2)));

            Assert.Equal(P(2, 1), _Service.GetNextPointInEdge(P(1, 1)));
            Assert.Equal(P(3, 1), _Service.GetNextPointInEdge(P(2, 1)));
            Assert.Equal(P(4, 1), _Service.GetNextPointInEdge(P(3, 1)));

            Assert.Equal(P(4, 2), _Service.GetNextPointInEdge(P(4, 1)));
            Assert.Equal(P(4, 3), _Service.GetNextPointInEdge(P(4, 2)));
            Assert.Equal(P(4, 4), _Service.GetNextPointInEdge(P(4, 3)));


            Assert.Equal(P(3, 4), _Service.GetNextPointInEdge(P(4, 4)));
            Assert.Equal(P(2, 4), _Service.GetNextPointInEdge(P(3, 4)));
            Assert.Equal(P(1, 4), _Service.GetNextPointInEdge(P(2, 4)));
            Assert.Equal(P(0, 4), _Service.GetNextPointInEdge(P(1, 4)));

            Assert.Equal(P(0, 3), _Service.GetNextPointInEdge(P(0, 4)));
            Assert.Equal(P(0, 2), _Service.GetNextPointInEdge(P(0, 3)));
            Assert.Equal(P(0, 1), _Service.GetNextPointInEdge(P(0, 2)));
            Assert.Equal(P(0, 0), _Service.GetNextPointInEdge(P(0, 1)));

            Assert.Equal(P(1, 0), _Service.GetNextPointInEdge(P(0, 0)));
            Assert.Equal(P(2, 0), _Service.GetNextPointInEdge(P(1, 0)));
            Assert.Equal(P(3, 0), _Service.GetNextPointInEdge(P(2, 0)));
            Assert.Equal(P(4, 0), _Service.GetNextPointInEdge(P(3, 0)));
            Assert.Equal(P(5, 0), _Service.GetNextPointInEdge(P(4, 0)));
        } 

        /**
         * 
         *       0  1  2  3  4
         *   0   X  X  X  X  X 
         *   1   X  X  X  X  X
         *   2   X  X  X  X  X
         *   3   X  X  X  X  X
         *   4   X  X  X  X  X
         * 
         * 
         */
    }
}