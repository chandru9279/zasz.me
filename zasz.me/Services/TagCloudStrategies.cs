using System;
using System.Collections.Generic;
using System.Drawing;

namespace zasz.me.Services
{
    public abstract class StrategyHandler
    {
        protected static readonly StringFormat HorizontalFormat;
        protected static readonly StringFormat VerticalFormat;
        protected static readonly Random Seed;

        static StrategyHandler()
        {
            VerticalFormat = new StringFormat();
            HorizontalFormat = new StringFormat();
            VerticalFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            Seed = new Random(DateTime.Now.Second);
        }

        public abstract StringFormat GetFormat();
    }

    internal class AllHorizontal : StrategyHandler
    {
        public override StringFormat GetFormat()
        {
            return HorizontalFormat;
        }
    }

    internal class AllVertical : StrategyHandler
    {
        public override StringFormat GetFormat()
        {
            return VerticalFormat;
        }
    }

    internal class RandomHorizontalOrVertical : StrategyHandler
    {
        private readonly double _Split;

        public RandomHorizontalOrVertical(double Split = 0.5)
        {
            _Split = Split;
        }

        public override StringFormat GetFormat()
        {
            return Seed.NextDouble() > _Split ? HorizontalFormat : VerticalFormat;
        }
    }

    internal class EqualHorizontalAndVertical : StrategyHandler
    {
        private bool _CurrentState;

        public EqualHorizontalAndVertical()
        {
            _CurrentState = Seed.NextDouble() > 0.5;
        }

        public override StringFormat GetFormat()
        {
            _CurrentState = !_CurrentState;
            return _CurrentState ? HorizontalFormat : VerticalFormat;
        }
    }


    public class TagCloudStrategies
    {
        public TagCloudStrategies()
        {
            Set = new Dictionary<TagDisplayStrategy, StrategyHandler>(6)
                              {
                                  {TagDisplayStrategy.EqualHorizontalAndVertical, new EqualHorizontalAndVertical()},
                                  {TagDisplayStrategy.AllHorizontal, new AllHorizontal()},
                                  {TagDisplayStrategy.AllVertical, new AllVertical()},
                                  {TagDisplayStrategy.RandomHorizontalOrVertical, new RandomHorizontalOrVertical()},
                                  {TagDisplayStrategy.MoreHorizontalThanVertical, new RandomHorizontalOrVertical(0.25)},
                                  {TagDisplayStrategy.MoreVerticalThanHorizontal, new RandomHorizontalOrVertical(0.75)}
                              };
        }

        public Dictionary<TagDisplayStrategy, StrategyHandler> Set { get; private set; }
    }

    public enum TagDisplayStrategy
    {
        EqualHorizontalAndVertical,
        AllHorizontal,
        AllVertical,
        RandomHorizontalOrVertical,
        MoreHorizontalThanVertical,
        MoreVerticalThanHorizontal
    }
}