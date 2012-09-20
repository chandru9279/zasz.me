using System;
using System.Collections.Generic;
using System.Drawing;
using Xunit;
using zasz.me.Services.TagCloud;

namespace zasz.health.ServiceTests
{
    public class TagCloudServiceTests
    {
        private readonly Func<int, int, PointF> p = (a, b) => new PointF(a, b);
        private readonly Func<PointF, SizeF, RectangleF> r = (a, b) => new RectangleF(a, b);
        private readonly Func<int, int, SizeF> s = (a, b) => new SizeF(a, b);

        private readonly TagCloudService service = new TagCloudService(new Dictionary<string, int>
                                                                            {
                                                                                {"asp.net", 15},
                                                                                {"games", 10},
                                                                                {"fun", 18},
                                                                                {"books", 5},
                                                                                {"music", 9},
                                                                                {"crapo", 1},
                                                                                {"dota", 2},
                                                                            }, 300, 300);

        [Fact]
        public void TryPointFailsOnCollision()
        {
            service.Occupied.Add(r(p(3, 0), s(1, 2)));
            Assert.False(service.TryPoint(p(2, 1), s(2, 1)));
            Assert.True(service.TryPoint(p(2, 2), s(2, 1)));

            service.Occupied.Add(r(p(0, 0), s(3, 3)));
            Assert.True(service.TryPoint(p(3, 2), s(1, 2)));
            Assert.True(service.TryPoint(p(0, 3), s(4, 1)));
            Assert.False(service.TryPoint(p(1, 1), s(1, 1)));
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
         */
        
        [Fact]
        public void GetNextPointInSpiralGoesInASpiral()
        {
            service.CurrentEdgeSize = 1;
            service.SleepingEdge = true;

            Assert.Equal(p(3, 2), service.GetSpiralNext(p(2, 2)));
            Assert.Equal(p(3, 3), service.GetSpiralNext(p(3, 2)));
            Assert.Equal(p(1, 3), service.GetSpiralNext(p(3, 3)));
            Assert.Equal(p(1, 1), service.GetSpiralNext(p(1, 3)));
            Assert.Equal(p(4, 1), service.GetSpiralNext(p(1, 1)));
            Assert.Equal(p(4, 4), service.GetSpiralNext(p(4, 1)));
            Assert.Equal(p(0, 4), service.GetSpiralNext(p(4, 4)));
            Assert.Equal(p(0, 0), service.GetSpiralNext(p(0, 4)));
            Assert.Equal(p(5, 0), service.GetSpiralNext(p(0, 0)));
        }


        [Fact]
        public void GetNextPointInEdgeGoesAlongAnEdge()
        {
            service.CurrentEdgeSize = 1;
            service.SleepingEdge = true;
            service.CurrentCorner = p(2, 2);
            service.Center = p(2, 2);

            Assert.Equal(p(3, 2), service.GetNextPointInEdge(p(2, 2)));

            Assert.Equal(p(3, 3), service.GetNextPointInEdge(p(3, 2)));

            Assert.Equal(p(2, 3), service.GetNextPointInEdge(p(3, 3)));
            Assert.Equal(p(1, 3), service.GetNextPointInEdge(p(2, 3)));

            Assert.Equal(p(1, 2), service.GetNextPointInEdge(p(1, 3)));
            Assert.Equal(p(1, 1), service.GetNextPointInEdge(p(1, 2)));

            Assert.Equal(p(2, 1), service.GetNextPointInEdge(p(1, 1)));
            Assert.Equal(p(3, 1), service.GetNextPointInEdge(p(2, 1)));
            Assert.Equal(p(4, 1), service.GetNextPointInEdge(p(3, 1)));

            Assert.Equal(p(4, 2), service.GetNextPointInEdge(p(4, 1)));
            Assert.Equal(p(4, 3), service.GetNextPointInEdge(p(4, 2)));
            Assert.Equal(p(4, 4), service.GetNextPointInEdge(p(4, 3)));


            Assert.Equal(p(3, 4), service.GetNextPointInEdge(p(4, 4)));
            Assert.Equal(p(2, 4), service.GetNextPointInEdge(p(3, 4)));
            Assert.Equal(p(1, 4), service.GetNextPointInEdge(p(2, 4)));
            Assert.Equal(p(0, 4), service.GetNextPointInEdge(p(1, 4)));

            Assert.Equal(p(0, 3), service.GetNextPointInEdge(p(0, 4)));
            Assert.Equal(p(0, 2), service.GetNextPointInEdge(p(0, 3)));
            Assert.Equal(p(0, 1), service.GetNextPointInEdge(p(0, 2)));
            Assert.Equal(p(0, 0), service.GetNextPointInEdge(p(0, 1)));

            Assert.Equal(p(1, 0), service.GetNextPointInEdge(p(0, 0)));
            Assert.Equal(p(2, 0), service.GetNextPointInEdge(p(1, 0)));
            Assert.Equal(p(3, 0), service.GetNextPointInEdge(p(2, 0)));
            Assert.Equal(p(4, 0), service.GetNextPointInEdge(p(3, 0)));
            Assert.Equal(p(5, 0), service.GetNextPointInEdge(p(4, 0)));
        }
    }
}