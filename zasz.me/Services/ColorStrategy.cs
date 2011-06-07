using System;
using System.Collections.Generic;
using System.Drawing;

namespace zasz.me.Services
{
    using ColorStrategies =
        Dictionary<ForegroundScheme, Func<HslColor, HslColor, BackgroundForegroundScheme, ColorStrategy>>;

    public abstract class ColorStrategy
    {
        private static readonly ColorStrategies _Set;

        protected readonly HslColor _Background;
        protected readonly HslColor _Foreground;
        protected Random _Seed;

        static ColorStrategy()
        {
            _Set = new ColorStrategies(6)
                       {
                           {
                               ForegroundScheme.Fixed,
                               (BgHsl, FgHsl, BgfgScheme) => new FixedForegroundStrategy(BgHsl, FgHsl)
                               },
                           {
                               ForegroundScheme.Varied,
                               (BgHsl, FgHsl, BgfgScheme) => new VariedForegroundStrategy(BgHsl, FgHsl, BgfgScheme)
                               },
                           {
                               ForegroundScheme.RandomVaried,
                               (BgHsl, FgHsl, BgfgScheme) =>
                               new RandomVariedForegroundStrategy(BgHsl, FgHsl, BgfgScheme)
                               }
                       };
        }

        protected ColorStrategy(HslColor Background, HslColor Foreground)
        {
            _Background = Background;
            _Foreground = Foreground;
            _Seed = new Random(DateTime.Now.Second);
        }

        public static ColorStrategy Get(BackgroundForegroundScheme BgfgScheme, ForegroundScheme FgScheme,
                                        Color Background, Color Foreground)
        {
            HslColor BgHsl = (BgfgScheme == BackgroundForegroundScheme.LightBgDarkFg)
                                 ? Background.Lighten()
                                 : Background.Darken();
            HslColor FgHsl = (BgfgScheme == BackgroundForegroundScheme.LightBgDarkFg)
                                 ? Foreground.Darken()
                                 : Foreground.Lighten();
            return _Set[FgScheme](BgHsl, FgHsl, BgfgScheme);
        }

        public Color GetBackGroundColor()
        {
            return _Background;
        }

        public abstract Color GetCurrentColor();
    }

    internal class FixedForegroundStrategy : ColorStrategy
    {
        public FixedForegroundStrategy(HslColor Background, HslColor Foreground)
            : base(Background, Foreground)
        {
        }

        public override Color GetCurrentColor()
        {
            return _Foreground;
        }
    }

    internal class VariedForegroundStrategy : ColorStrategy
    {
        private readonly double _Range;

        public VariedForegroundStrategy(HslColor Background, HslColor Foreground, BackgroundForegroundScheme BgfgScheme)
            : base(Background, Foreground)
        {
            /* Dark foreground needed, so Luminosity is reduced to somewhere between 0 & 0.5
             * Saturation is full so the color comes out, removing all blackness/greyness
             * For Light foreground Luminosity is kept between 0.5 & 1
             */
            _Foreground.Saturation = 1.0;
            _Range = (BgfgScheme == BackgroundForegroundScheme.LightBgDarkFg) ? 0d : 0.5;
        }

        public override Color GetCurrentColor()
        {
            _Foreground.Luminosity = (_Seed.NextDouble()*0.5) + _Range;
            return _Foreground;
        }
    }

    internal class RandomVariedForegroundStrategy : VariedForegroundStrategy
    {
        public RandomVariedForegroundStrategy(HslColor Background, HslColor Foreground,
                                              BackgroundForegroundScheme BgfgScheme)
            : base(Background, Foreground, BgfgScheme)
        {
        }

        public override Color GetCurrentColor()
        {
            _Foreground.Hue = _Seed.NextDouble();
            return base.GetCurrentColor();
        }
    }

    public enum BackgroundForegroundScheme
    {
        DarkBgLightFg,
        LightBgDarkFg
    }

    public enum ForegroundScheme
    {
        Fixed,
        Varied,
        RandomVaried
    }

    public static class ColorExtension
    {
        public static HslColor Lighten(this Color Given)
        {
            HslColor ColorHsl = Given;
            if (ColorHsl.Luminosity < 0.5) ColorHsl.Luminosity = 0.75;
            return ColorHsl;
        }

        public static HslColor Darken(this Color Given)
        {
            HslColor ColorHsl = Given;
            if (ColorHsl.Luminosity > 0.5) ColorHsl.Luminosity = 0.25;
            return ColorHsl;
        }
    }
}