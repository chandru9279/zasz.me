using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;

namespace zasz.me.Services
{
    public class TagCloudService
    {
        private readonly Func<float, float> _Decrement = (It => It - 1);
        private readonly int _HighestWeight;
        private readonly Func<float, float> _Increment = (It => It + 1);
        private readonly int _LowestWeight;
        internal readonly List<RectangleF> _Occupied;
        private readonly Dictionary<string, int> _TagsSorted;
        internal PointF _Center;
        private Func<float, float> _Change;
        internal PointF _CurrentEdgeLimit;
        internal int _CurrentEdgeSize;
        internal bool _EdgeUnused;
        private float _FontHeightSpan;

        private int _WeightSpan;

        public TagCloudService(Dictionary<string, int> Tags)
        {
            var Sorted = from Tag in Tags
                         orderby Tag.Value descending
                         select new {Tag.Key, Tag.Value};
            _TagsSorted = Sorted.ToDictionary(It => It.Key, It => It.Value);
            _LowestWeight = _TagsSorted.Last().Value;
            _HighestWeight = _TagsSorted.First().Value;
            _Occupied = new List<RectangleF>(_TagsSorted.Count);
            ApplyDefaults();
        }

        /// <summary>
        /// Default is Times New Roman
        /// </summary>
        public FontFamily SelectedFont { get; set; }

        /// <summary>
        /// Size of the smallest string in the TagCloud
        /// </summary>
        public float MinimumFontSize { get; set; }

        /// <summary>
        /// Size of the largest string in the TagCloud
        /// </summary>
        public float MaximumFontSize { get; set; }

        /// <summary>
        /// Use <code>DisplayStrategy.Get()</code> to get a Display Strategy
        /// Default is RandomHorizontalOrVertical.
        /// </summary>
        public DisplayStrategy DisplayChoice { get; set; }

        /// <summary>
        /// Use <code>ColorStrategy.Get()</code> to get a Color Strategy
        /// Default is white background and random darker foreground colors.
        /// </summary>
        public ColorStrategy ColorChoice { get; set; }

        /// <summary>
        /// A rotate transform will be applied on the whole image based on this 
        /// Angle in degrees
        /// </summary>
        public int Angle { get; set; }

        private void ApplyDefaults()
        {
            SelectedFont = new FontFamily("Times New Roman");
            MinimumFontSize = 1f;
            MaximumFontSize = 5f;
            Angle = 0;
            DisplayChoice = DisplayStrategy.Get(TagDisplayStrategy.RandomHorizontalOrVertical);
            ColorChoice = ColorStrategy.Get(BackgroundForegroundScheme.LightBgDarkFg, ForegroundScheme.RandomVaried,
                                            Color.White, Color.Black);
        }

        public Bitmap Get(int Width, int Height)
        {
            var TheCloudBitmap = new Bitmap(Width, Height);
            Graphics GImage = Graphics.FromImage(TheCloudBitmap);
            GImage.TextRenderingHint = TextRenderingHint.AntiAlias;
            _Center = new PointF(TheCloudBitmap.Height/2f, TheCloudBitmap.Width/2f);
            if (Angle != 0) Rotate(GImage);
            _WeightSpan = _HighestWeight - _LowestWeight;
            if (MaximumFontSize < MinimumFontSize)
                throw new ServiceRequirementException("MaximumFontSize is less than MinimumFontSize");
            _FontHeightSpan = MaximumFontSize - MinimumFontSize;
            GImage.Clear(ColorChoice.GetBackGroundColor());

            foreach (var Tag in _TagsSorted)
            {
                var FontToApply = new Font(SelectedFont, CalculateFontSize(Tag.Value));
                SizeF StringBounds = GImage.MeasureString(Tag.Key, FontToApply);
                StringFormat Format = DisplayChoice.GetFormat();
                if (Format.FormatFlags.HasFlag(StringFormatFlags.DirectionVertical))
                {
                    float StringWidth = StringBounds.Width;
                    StringBounds.Width = StringBounds.Height;
                    StringBounds.Height = StringWidth;
                }
                PointF TopRight = CalculateWhere(StringBounds);
                GImage.DrawString(Tag.Key, FontToApply, new SolidBrush(ColorChoice.GetCurrentColor()), TopRight, Format);
                /* Uncomment this to see word boundaries.
                GImage.DrawRectangle(Pens.Black, TopRight.X, TopRight.Y, StringBounds.Width, StringBounds.Height);
                 */
                _Occupied.Add(new RectangleF(TopRight, StringBounds));
            }
            return TheCloudBitmap;
        }

        private void Rotate(Graphics GImage)
        {
            GImage.TranslateTransform(_Center.X, _Center.Y);
            GImage.RotateTransform(Angle);
            GImage.TranslateTransform(-_Center.X, -_Center.Y);
        }

        private PointF CalculateWhere(SizeF Measure)
        {
            _CurrentEdgeSize = 1;
            _EdgeUnused = true;
            _CurrentEdgeLimit = _Center;

            PointF Point = _Center;
            while (TryPoint(Point, Measure) == false)
                Point = GetNextPointInEdge(Point);
            return Point;
        }

        internal bool TryPoint(PointF TrialPoint, SizeF Rectangle)
        {
            var TrailRectangle = new RectangleF(TrialPoint, Rectangle);
            return !_Occupied.Any(It => It.IntersectsWith(TrailRectangle));
        }

        /*
         * This method gives points that crawls along an edge of the spiral, described below.
         */

        internal PointF GetNextPointInEdge(PointF Point)
        {
            if (Point.Equals(_CurrentEdgeLimit))
            {
                _Change = (_CurrentEdgeSize & 1) == 0 ? _Decrement : _Increment;
                _CurrentEdgeLimit = GetSpiralNext(_CurrentEdgeLimit);
            }
            return Point.X == _CurrentEdgeLimit.X
                       ? new PointF(Point.X, _Change(Point.Y))
                       : new PointF(_Change(Point.X), Point.Y);
        }

        /* Imagine a grid of 5x5 points, and 0,0 and 4,4 are the topright and bottomleft respectively.
         * You can move in a spiral by navigating as follows:
         * 1. Inc GivenPoint's X by 1 and return it.
         * 2. Inc GivenPoint's Y by 1 and return it.
         * 3. Dec GivenPoint's X by 2 and return it.
         * 4. Dec GivenPoint's Y by 2 and return it.
         * 5. Inc GivenPoint's X by 3 and return it.
         * 6. Inc GivenPoint's Y by 3 and return it.
         * 7. Dec GivenPoint's X by 4 and return it.
         * 8. Dec GivenPoint's Y by 4 and return it.
         * 
         * I'm calling the values 1,2,3,4 etc as _EdgeSize. Any joining of points in a graph is an edge.
         * To find out if we need to increment or decrement I'm using the condition _EdgeSize is even or not.
         * To increment EdgeSize, using a boolean _EdgeUnused to count upto 2 steps. I'll blog about this later
         * at chandruon.net!
         * 
         *       0  1  2  3  4
         *   0   X  X  X  X  X 
         *   1   X  X  X  X  X
         *   2   X  X  X  X  X
         *   3   X  X  X  X  X
         *   4   X  X  X  X  X
         * 
         */

        internal PointF GetSpiralNext(PointF TrialPoint)
        {
            float X = TrialPoint.X, Y = TrialPoint.Y;

            bool EdgeSizeEven = (_CurrentEdgeSize & 1) == 0;
            if (_EdgeUnused)
            {
                X = EdgeSizeEven ? TrialPoint.X - _CurrentEdgeSize : TrialPoint.X + _CurrentEdgeSize;
                _EdgeUnused = false;
            }
            else
            {
                Y = EdgeSizeEven ? TrialPoint.Y - _CurrentEdgeSize : TrialPoint.Y + _CurrentEdgeSize;
                _CurrentEdgeSize++;
                _EdgeUnused = true;
            }
            return new PointF(X, Y);
        }

        // Range Mapping
        private float CalculateFontSize(int Weight)
        {
            // Convert the Weight into a 0-1 range (float)
            float WeightScaled = Weight - _LowestWeight/(float) _WeightSpan;
            // Convert the 0-1 range into a value in the Font range.
            return MinimumFontSize + (WeightScaled*_FontHeightSpan);
        }
    }

    public class ServiceRequirementException : Exception
    {
        public ServiceRequirementException(string Message) : base(Message)
        {
        }
    }
}