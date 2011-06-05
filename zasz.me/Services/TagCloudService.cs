using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace zasz.me.Services
{
    public class TagCloudService
    {
        private readonly StringFormat _HorizontalFormat;
        private readonly int _LowestWeight;
        private readonly int _HighestWeight;
        internal readonly List<RectangleF> _Occupied;
        private readonly Random _Seed;
        private readonly Dictionary<string, int> _Tags;
        private readonly Dictionary<string, int> _TagsSorted;
        private readonly StringFormat _VerticalFormat;
        private PointF _Center;
        private int _CurrentEdgeSize = 1;
        private bool _EdgeUnused = true;
        private int _WeightSpan;
        private float _FontSpan;

        public TagCloudService(Dictionary<string, int> Tags)
        {
            _Tags = Tags;
            var Sorted = from Tag in _Tags
                         orderby Tag.Value descending
                         select new {Tag.Key, Tag.Value};
            _TagsSorted = Sorted.ToDictionary(It => It.Key, It => It.Value);
            _LowestWeight = _TagsSorted.Last().Value;
            _HighestWeight = _TagsSorted.First().Value;
            _VerticalFormat = new StringFormat();
            _HorizontalFormat = new StringFormat();
            _VerticalFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            _Seed = new Random(DateTime.Now.Second);
            _Occupied = new List<RectangleF>(_Tags.Count);
            ApplyDefaults();
        }

        public string FontName { get; set; }

        public float MinimumFontSize { get; set; }

        public float MaximumFontSize { get; set; }

        private void ApplyDefaults()
        {   
            FontName = "Arial";
            MinimumFontSize = 10f;
            MaximumFontSize = 30f;
        }

        public Bitmap Get(int Width, int Height)
        {
            var TheCloudBitmap = new Bitmap(Width, Height);
            Graphics GImage = Graphics.FromImage(TheCloudBitmap);
            _Center = new PointF(TheCloudBitmap.Height/2f, TheCloudBitmap.Width/2f);
            _WeightSpan = _HighestWeight - _LowestWeight;
            if(MaximumFontSize < MinimumFontSize)
                throw new ArgumentException("MaximumFontSize is less than MinimumFontSize");
            _FontSpan = MaximumFontSize - MinimumFontSize;

            foreach (var Tag in _TagsSorted)
            {
                var FontToApply = new Font(FontName, CalculateFontSize(Tag.Value));
                SizeF StringBounds = GImage.MeasureString(Tag.Key, FontToApply);
                StringFormat Format = CalculateHow();
                if(ReferenceEquals(Format, _VerticalFormat))
                {
                    var StringWidth = StringBounds.Width;
                    StringBounds.Width = StringBounds.Height;
                    StringBounds.Height = StringWidth;
                }
                PointF TopRight = CalculateWhere(StringBounds);
                GImage.DrawString(Tag.Key, FontToApply, Brushes.Black, TopRight, Format);
                GImage.DrawRectangle(Pens.Black, TopRight.X, TopRight.Y, StringBounds.Width, StringBounds.Height);
                _Occupied.Add(new RectangleF(TopRight, StringBounds));
            }
            return TheCloudBitmap;
        }

        private StringFormat CalculateHow()
        {
            return _Seed.NextDouble() > 0.5 ? _VerticalFormat : _HorizontalFormat;
        }

        private PointF CalculateWhere(SizeF Measure)
        {
            PointF Point = _Center;
            while (TryPoint(Point, Measure) == false)
                Point = GetSpiralNext(Point);
            return Point;
        }

        internal bool TryPoint(PointF TrialPoint, SizeF Rectangle)
        {
            var TrailRectangle = new RectangleF(TrialPoint, Rectangle);
            return !_Occupied.Any(It => It.IntersectsWith(TrailRectangle));
        }

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
            var WeightScaled = Weight - _LowestWeight / (float)_WeightSpan;

            // Convert the 0-1 range into a value in the Font range.
            return MinimumFontSize + (WeightScaled * _FontSpan);
        }
    }
}