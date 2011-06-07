using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;

namespace zasz.me.Services
{
    public class TagCloudService
    {
        internal readonly List<Rectangle> _Borders;
        private readonly Func<float, float> _Decrement = (It => It - 1);
        private readonly int _Height;
        private readonly int _HighestWeight;
        private readonly Func<float, float> _Increment = (It => It + 1);
        private readonly int _LowestWeight;
        internal readonly List<RectangleF> _Occupied;
        private readonly Dictionary<string, int> _TagsSorted;
        private readonly int _Width;
        internal PointF _Center;
        private Func<float, float> _Change;
        internal PointF _CurrentEdgeLimit;
        internal int _CurrentEdgeSize;
        internal bool _EdgeUnused;
        private float _FontHeightSpan;

        private int _WeightSpan;

        public TagCloudService(Dictionary<string, int> Tags, int Width, int Height)
        {
            _Width = Width;
            _Height = Height;
            var Sorted = from Tag in Tags
                         orderby Tag.Value descending
                         select new {Tag.Key, Tag.Value};
            _TagsSorted = Sorted.ToDictionary(It => It.Key, It => It.Value);
            _LowestWeight = _TagsSorted.Last().Value;
            _HighestWeight = _TagsSorted.First().Value;
            _Occupied = new List<RectangleF>(_TagsSorted.Count);
            _Borders = new List<Rectangle>();
            ApplyDefaults();
        }

        /// <summary>
        /// Default is Times New Roman
        /// </summary>
        public FontFamily SelectedFont { get; set; }

        /// <summary>
        /// Default is false, Enable to start seeing Word boundaries used for
        /// collision detection.
        /// </summary>
        public bool ShowWordBoundaries { get; set; }

        /// <summary>
        /// Set this to true, if vertical must needs to appear with RHS as floor
        /// Default is LHS is the floor and RHS is ceiling of the Text.
        /// </summary>
        public bool VerticalTextRight { get; set; }

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

        /// <summary>
        /// Default is false. Set this to true to crop out blank background.
        /// </summary>
        public bool Crop { get; set; }

        /// <summary>
        /// Default is 30px.
        /// </summary>
        public float Margin { get; set; }

        private void ApplyDefaults()
        {
            SelectedFont = new FontFamily("Times New Roman");
            MinimumFontSize = 1f;
            MaximumFontSize = 5f;
            Angle = 0;
            DisplayChoice = DisplayStrategy.Get(TagDisplayStrategy.RandomHorizontalOrVertical);
            ColorChoice = ColorStrategy.Get(Theme.LightBgDarkFg, Style.RandomVaried,
                                            Color.White, Color.Black);
            VerticalTextRight = false;
            ShowWordBoundaries = false;
            Margin = 30f;
        }

        public Bitmap Construct(out List<Rectangle> Borders)
        {
            var TheCloudBitmap = new Bitmap(_Width, _Height);
            Graphics GImage = Graphics.FromImage(TheCloudBitmap);
            GImage.TextRenderingHint = TextRenderingHint.AntiAlias;
            _Center = new PointF(TheCloudBitmap.Height/2f, TheCloudBitmap.Width/2f);
            if (Angle != 0) Rotate(GImage, _Center, Angle);
            _WeightSpan = _HighestWeight - _LowestWeight;
            if (MaximumFontSize < MinimumFontSize)
                throw new Exception("MaximumFontSize is less than MinimumFontSize");
            _FontHeightSpan = MaximumFontSize - MinimumFontSize;
            GImage.Clear(ColorChoice.GetBackGroundColor());

            foreach (var Tag in _TagsSorted)
            {
                var FontToApply = new Font(SelectedFont, CalculateFontSize(Tag.Value));
                SizeF StringBounds = GImage.MeasureString(Tag.Key, FontToApply);
                StringFormat Format = DisplayChoice.GetFormat();
                bool IsVertical = Format.FormatFlags.HasFlag(StringFormatFlags.DirectionVertical);
                if (IsVertical)
                {
                    float StringWidth = StringBounds.Width;
                    StringBounds.Width = StringBounds.Height;
                    StringBounds.Height = StringWidth;
                }
                PointF TopLeft = CalculateWhere(StringBounds);
                PointF TextCenter = IsVertical & VerticalTextRight
                                        ? new PointF(TopLeft.X + (StringBounds.Width/2f),
                                                     TopLeft.Y + (StringBounds.Height/2f))
                                        : TopLeft;
                var CurrentBrush = new SolidBrush(ColorChoice.GetCurrentColor());
                if (IsVertical & VerticalTextRight) Rotate(GImage, TextCenter, -180);
                GImage.DrawString(Tag.Key, FontToApply, CurrentBrush, TopLeft, Format);
                if (IsVertical & VerticalTextRight) Rotate(GImage, TextCenter, 180);
                if (ShowWordBoundaries)
                    GImage.DrawRectangle(new Pen(CurrentBrush), TopLeft.X, TopLeft.Y, StringBounds.Width,
                                         StringBounds.Height);
                _Occupied.Add(new RectangleF(TopLeft, StringBounds));
            }
            Borders = _Borders;
            GImage.Dispose();
            return CropFillBorders(TheCloudBitmap);
        }

        private static void Rotate(Graphics GImage, PointF About, int ByAngle)
        {
            GImage.TranslateTransform(About.X, About.Y);
            GImage.RotateTransform(ByAngle);
            GImage.TranslateTransform(-About.X, -About.Y);
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
            // Strange case where all tags have equal weights
            if (_WeightSpan == 0) return (MinimumFontSize + MaximumFontSize)/2f;
            // Convert the Weight into a 0-1 range (float)
            float WeightScaled = (Weight - _LowestWeight)/(float) _WeightSpan;
            // Convert the 0-1 range into a value in the Font range.
            return MinimumFontSize + (WeightScaled*_FontHeightSpan);
        }

        internal Bitmap CropFillBorders(Bitmap Incoming)
        {
            if (Crop)
            {
                Bitmap Cropped;
                float NewTop;
                float NewLeft;
                CropIt(Incoming, out Cropped, out NewTop, out NewLeft);
                FillBorders(NewTop, NewLeft);
                return Cropped;
            }
            FillBorders(0f, 0f);
            return Incoming;
        }

        private void CropIt(Bitmap Incoming, out Bitmap Cropped, out float NewTop, out float NewLeft)
        {
            NewTop = _Occupied.Select(It => It.Top).Min() - Margin;
            NewLeft = _Occupied.Select(It => It.Left).Min() - Margin;

            float Bottom = _Occupied.Select(It => It.Bottom).Max() + Margin;
            float Right = _Occupied.Select(It => It.Right).Max() + Margin;

            if (NewTop < 0) NewTop = 0;
            if (NewLeft < 0) NewLeft = 0;

            if (Bottom > _Height) Bottom = _Height;
            if (Right > _Width) Right = _Width;

            var Rectangle = new RectangleF(NewLeft, NewTop, Right - NewLeft, Bottom - NewTop);
            Cropped = Incoming.Clone(Rectangle, Incoming.PixelFormat);
        }

        private void FillBorders(float NewTop, float NewLeft)
        {
            foreach (RectangleF Rect in _Occupied)
            {
                _Borders.Add(new Rectangle((int) Math.Round(Rect.X - NewLeft), (int) Math.Round(Rect.Y - NewTop),
                                           (int) Math.Round(Rect.Width), (int) Math.Round(Rect.Height)));
            }
        }
    }
}