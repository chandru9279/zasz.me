using System;
using System.Collections.Generic;
using System.Drawing;

namespace zasz.me.Services.TagCloud
{
    public abstract class ColorStrategy
    {
        private static readonly Dictionary<Style, Func<Color, HslColor, Theme, ColorStrategy>> set;

        protected internal HslColor Foreground;
        protected internal Color Background;
        protected Random Seed;

        static ColorStrategy()
        {
            set = new Dictionary<Style, Func<Color, HslColor, Theme, ColorStrategy>>(3);
            set.Add(Style.Fixed, (bgHsl, fgHsl, theme) => new FixedForeground(bgHsl, fgHsl));
            set.Add(Style.Varied, (bgHsl, fgHsl, theme) => new VariedForeground(bgHsl, fgHsl, theme));
            set.Add(Style.RandomVaried, (bgHsl, fgHsl, theme) => new RandomVaried(bgHsl, fgHsl, theme));
            set.Add(Style.Random, (bgHsl, fgHsl, theme) => new RandomForeground(bgHsl, fgHsl));
            set.Add(Style.Grayscale, (bgHsl, fgHsl, theme) => new Grayscale(bgHsl, fgHsl, theme));
        }

        protected ColorStrategy(Color background, HslColor foreground)
        {
            Background = background;
            Foreground = foreground;
            Seed = new Random(DateTime.Now.Second);
        }

        public static ColorStrategy Get(Theme theme, Style style,
                                        Color background, Color foreground)
        {
            var fgHsl = (theme == Theme.LightBgDarkFg)
                            ? foreground.Darken()
                            : foreground.Lighten();
            if (background.A != 255) /* Not interfering with any transparent color */
                return set[style](background, fgHsl, theme);
            var bgHsl = (theme == Theme.LightBgDarkFg)
                            ? background.Lighten()
                            : background.Darken();
            return set[style]((Color) bgHsl, fgHsl, theme);
        }

        public Color GetBackGroundColor()
        {
            return Background;
        }

        public abstract Color GetCurrentColor();
    }

    internal class FixedForeground : ColorStrategy
    {
        public FixedForeground(Color background, HslColor foreground)
            : base(background, foreground)
        {
        }

        public override Color GetCurrentColor()
        {
            return (Color) Foreground;
        }
    }

    internal class RandomForeground : FixedForeground
    {
        public RandomForeground(Color background, HslColor foreground)
            : base(background, foreground)
        {
        }

        public override Color GetCurrentColor()
        {
            Foreground.Hue = Seed.NextDouble();
            return (Color) Foreground;
        }
    }

    internal class VariedForeground : ColorStrategy
    {
        protected readonly double Range;

        public VariedForeground(Color background, HslColor foreground, Theme theme)
            : base(background, foreground)
        {
            /* Dark foreground needed, so Luminosity is reduced to somewhere between 0 & 0.5
             * Saturation is full so the color comes out, removing all blackness/greyness
             * For Light foreground Luminosity is kept between 0.5 & 1
             */
            Foreground.Saturation = 1.0;
            Range = (theme == Theme.LightBgDarkFg) ? 0d : 0.5;
        }

        public override Color GetCurrentColor()
        {
            Foreground.Luminosity = (Seed.NextDouble()*0.5) + Range;
            return (Color) Foreground;
        }
    }

    internal class RandomVaried : VariedForeground
    {
        public RandomVaried(Color background, HslColor foreground, Theme theme)
            : base(background, foreground, theme)
        {
        }

        public override Color GetCurrentColor()
        {
            Foreground.Hue = Seed.NextDouble();
            return base.GetCurrentColor();
        }
    }

    internal class Grayscale : VariedForeground
    {
        public Grayscale(Color background, HslColor foreground, Theme theme)
            : base(background, foreground, theme)
        {
            /* Saturation is 0 - Meaning no color specified by hue can be seen at all. 
             * So luminance is now reduced to showing grayscale */
            Foreground.Saturation = 0.0;
            Background = Color.FromArgb(background.A, theme == Theme.LightBgDarkFg ? Color.White : Color.Black);
        }
    }

    public enum Theme
    {
        DarkBgLightFg,
        LightBgDarkFg
    }

    public enum Style
    {
        Fixed,
        Random,
        Varied,
        RandomVaried,
        Grayscale
    }

    public static class ColorExtension
    {
        public static HslColor Lighten(this Color given)
        {
            var colorHsl = (HslColor) given;
            if (colorHsl.Luminosity < 0.5) colorHsl.Luminosity = 0.75;
            return colorHsl;
        }

        public static HslColor Darken(this Color given)
        {
            var colorHsl = (HslColor) given;
            if (colorHsl.Luminosity > 0.5) colorHsl.Luminosity = 0.25;
            return colorHsl;
        }
    }
}