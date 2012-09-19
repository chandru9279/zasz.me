using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;

namespace zasz.me.Services.TagCloud
{
    public class TagCloudService
    {
        private readonly Func<float, float> decrement;
        private readonly Action<string> die = msg => { throw new Exception(msg); };

        private readonly int height;

        private readonly int highestWeight;
        private readonly Func<float, float> increment;
        private readonly int lowestWeight;
        private readonly RectangleF mainArea;

        private readonly PointF spiralEndSentinel;
        private readonly Dictionary<string, int> tagsSorted;
        private readonly int width;
        internal PointF Center;
        internal PointF CurrentCorner;
        internal int CurrentEdgeSize;
        private Func<float, float> edgeDirection;
        private float fontHeightSpan;
        internal int MaxEdgeSize;
        internal List<RectangleF> Occupied;

        private bool serviceObjectNew = true;
        internal bool SleepingEdge;
        private int spiralRoom;
        private int weightSpan;

        public TagCloudService(Dictionary<string, int> tags, int width, int height)
        {
            increment = x => x + spiralRoom;
            decrement = x => x - spiralRoom;
            if (null == tags || 0 == tags.Count)
                die("Argument Exception, No Tags to disorganize");
            if (width < 30 || height < 30)
                die("Way too low Width or Height for the cloud to be useful");
            this.width = width;
            this.height = height;
            mainArea = new RectangleF(0, 0, width, height);
            MaxEdgeSize = width >= height ? width : height;
            /* Sentinel is a definitely out of bounds point that the spiral normally
             * should never reach. */
            spiralEndSentinel = new PointF(MaxEdgeSize + 10, MaxEdgeSize + 10);
            var sorted = from tag in tags
                         orderby tag.Value descending
                         select new {tag.Key, tag.Value};
            tagsSorted = sorted.ToDictionary(x => x.Key, x => x.Value);
            lowestWeight = tagsSorted.Last().Value;
            highestWeight = tagsSorted.First().Value;
            Occupied = new List<RectangleF>(tagsSorted.Count + 4);
            WordsSkipped = new Dictionary<string, int>();
            ApplyDefaults();
        }

        /// <summary>
        ///   Default is Times New Roman
        /// </summary>
        public FontFamily SelectedFont { get; set; }

        /// <summary>
        ///   Default is false, Enable to start seeing Word boundaries used for
        ///   collision detection.
        /// </summary>
        public bool ShowWordBoundaries { get; set; }

        /// <summary>
        ///   Set this to true, if vertical must needs to appear with RHS as floor
        ///   Default is LHS is the floor and RHS is ceiling of the Text.
        /// </summary>
        public bool VerticalTextRight { get; set; }

        /// <summary>
        ///   Size of the smallest string in the TagCloud
        /// </summary>
        public float MinimumFontSize { get; set; }

        /// <summary>
        ///   Size of the largest string in the TagCloud
        /// </summary>
        public float MaximumFontSize { get; set; }

        /// <summary>
        ///   Use <code>DisplayStrategy.Get()</code> to get a Display Strategy
        ///   Default is RandomHorizontalOrVertical.
        /// </summary>
        public DisplayStrategy DisplayChoice { get; set; }

        /// <summary>
        ///   Use <code>ColorStrategy.Get()</code> to get a Color Strategy
        ///   Default is white background and random darker foreground colors.
        /// </summary>
        public ColorStrategy ColorChoice { get; set; }

        /// <summary>
        ///   A rotate transform will be applied on the whole image based on this 
        ///   Angle in degrees. Which means the Boundaries are not usable for hover animations
        ///   in CSS/HTML.
        /// </summary>
        public int Angle { get; set; }

        /// <summary>
        ///   Default is false. Set this to true to crop out blank background.
        /// </summary>
        public bool Crop { get; set; }

        /// <summary>
        ///   Default is 30px.
        /// </summary>
        public float Margin { get; set; }

        /// <summary>
        ///   Default is 0. The higher the number, the more roomy
        ///   the tag cloud is, and more performant the service is.
        ///   Don't go over 20 for good results
        /// </summary>
        public int SpiralRoom
        {
            get { return spiralRoom/2 - 1; }
            set { spiralRoom = 2*value + 1; }
        }

        /// <summary>
        ///   Words that were not rendered because of non-availability
        ///   of free area to render them. If count is anything other than 0
        ///   use a bigger bitmap as input with more area.
        /// </summary>
        public Dictionary<string, int> WordsSkipped { get; set; }

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
            SpiralRoom = 0;

            /* Adding 4 Rectangles on the border to make sure that words dont go outside the border.
             * Words going outside the border will collide on these and hence be placed elsewhere.
             */
            Occupied.Add(new RectangleF(0, -1, width, 1));
            Occupied.Add(new RectangleF(-1, 0, 1, height));
            Occupied.Add(new RectangleF(0, height, width, 1));
            Occupied.Add(new RectangleF(width, 0, 1, height));
        }

        public Bitmap Construct(out Dictionary<string, RectangleF> Borders)
        {
            if (serviceObjectNew)
                serviceObjectNew = false;
            else
                die("This object has been used. Dispose this, create and use a new Service object.");
            var theCloudBitmap = new Bitmap(width, height);
            var gImage = Graphics.FromImage(theCloudBitmap);
            gImage.TextRenderingHint = TextRenderingHint.AntiAlias;
            Center = new PointF(theCloudBitmap.Width/2f, theCloudBitmap.Height/2f);
            if (Angle != 0) gImage.Rotate(Center, Angle);
            weightSpan = highestWeight - lowestWeight;
            if (MaximumFontSize < MinimumFontSize)
                die("MaximumFontSize is less than MinimumFontSize");
            fontHeightSpan = MaximumFontSize - MinimumFontSize;
            gImage.Clear(ColorChoice.GetBackGroundColor());

            foreach (var tag in tagsSorted)
            {
                var fontToApply = new Font(SelectedFont, CalculateFontSize(tag.Value));
                var stringBounds = gImage.MeasureString(tag.Key, fontToApply);
                var format = DisplayChoice.GetFormat();
                var isVertical = format.FormatFlags.HasFlag(StringFormatFlags.DirectionVertical);
                if (isVertical)
                {
                    var stringWidth = stringBounds.Width;
                    stringBounds.Width = stringBounds.Height;
                    stringBounds.Height = stringWidth;
                }
                var topLeft = CalculateWhere(stringBounds);
                /* Strategy chosen display format, failed to be placed */
                if (topLeft.Equals(spiralEndSentinel))
                {
                    WordsSkipped.Add(tag.Key, tag.Value);
                    continue;
                }
                var textCenter = isVertical & VerticalTextRight
                                     ? new PointF(topLeft.X + (stringBounds.Width/2f),
                                                  topLeft.Y + (stringBounds.Height/2f))
                                     : topLeft;
                var currentBrush = new SolidBrush(ColorChoice.GetCurrentColor());
                if (isVertical & VerticalTextRight) gImage.Rotate(textCenter, -180);
                gImage.DrawString(tag.Key, fontToApply, currentBrush, topLeft, format);
                if (isVertical & VerticalTextRight) gImage.Rotate(textCenter, 180);
                if (ShowWordBoundaries)
                    gImage.DrawRectangle(new Pen(currentBrush), topLeft.X, topLeft.Y, stringBounds.Width,
                                         stringBounds.Height);
                Occupied.Add(new RectangleF(topLeft, stringBounds));
            }
            gImage.Dispose();
            Occupied.RemoveRange(0, 4);
            if (Crop)
                theCloudBitmap = CropAndTranslate(theCloudBitmap);
            Borders = Occupied
                .Zip(tagsSorted.Keys.Where(word => !WordsSkipped.ContainsKey(word)), (rect, tag) => new {rect, tag})
                .ToDictionary(x => x.tag, x => x.rect);
            return theCloudBitmap;
        }

        private PointF CalculateWhere(SizeF measure)
        {
            CurrentEdgeSize = spiralRoom;
            SleepingEdge = true;
            CurrentCorner = Center;

            var currentPoint = Center;
            while (TryPoint(currentPoint, measure) == false)
                currentPoint = GetNextPointInEdge(currentPoint);
            return currentPoint;
        }

        internal bool TryPoint(PointF trialPoint, SizeF rectangle)
        {
            if (trialPoint.Equals(spiralEndSentinel)) return true;
            var trailRectangle = new RectangleF(trialPoint, rectangle);
            return !Occupied.Any(x => x.IntersectsWith(trailRectangle));
        }

        /*
         * This method gives points that crawls along an edge of the spiral, described below.
         */

        internal PointF GetNextPointInEdge(PointF current)
        {
            do
            {
                if (current.Equals(CurrentCorner))
                {
                    CurrentCorner = GetSpiralNext(CurrentCorner);
                    if (CurrentCorner.Equals(spiralEndSentinel)) return spiralEndSentinel;
                }
                current = current.X == CurrentCorner.X
                              ? new PointF(current.X, edgeDirection(current.Y))
                              : new PointF(edgeDirection(current.X), current.Y);
            } while (!mainArea.Contains(current));
            return current;
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
         * To increment EdgeSize, using a boolean _SleepingEdge to count upto 2 steps. I'll blog about this later
         * at zasz.me!
         * 
         *       0  1  2  3  4
         *   0   X  X  X  X  X     .-------->
         *   1   X  X  X  X  X     | .-----.  
         *   2   X  X  X  X  X     | | --. |    
         *   3   X  X  X  X  X     | '---' |    
         *   4   X  X  X  X  X     '-------'    
         *   
         * 
         * Depth of Recursion is meant to be at most ONE in this method, 
         * and only when outlying edges are to be skipped.
         * 
         */

        internal PointF GetSpiralNext(PointF previousCorner)
        {
            float x = previousCorner.X, y = previousCorner.Y;
            var edgeSizeEven = (CurrentEdgeSize & 1) == 0;

            if (SleepingEdge)
            {
                x = edgeSizeEven ? previousCorner.X - CurrentEdgeSize : previousCorner.X + CurrentEdgeSize;
                SleepingEdge = false;
                /* Next edge will be standing. Sleeping = Parallal to X-Axis; Standing = Parallal to Y-Axis */
            }
            else
            {
                y = edgeSizeEven ? previousCorner.Y - CurrentEdgeSize : previousCorner.Y + CurrentEdgeSize;
                CurrentEdgeSize += spiralRoom;
                SleepingEdge = true;
            }

            edgeDirection = edgeSizeEven ? decrement : increment;

            /* If the spiral widens to a point where its arms are longer than the Height & Width, 
             * it's time to end the spiral and give up placing the word. There is no 'point'
             * (no pun intended) in going for wider spirals, as you are out of bounds now.
             * Our spiral is an Archimedean Right spiral, made up of Line segments @ 
             * right-angles to each other.
             */
            return CurrentEdgeSize > MaxEdgeSize ? spiralEndSentinel : new PointF(x, y);
        }

        // Range Mapping
        private float CalculateFontSize(int weight)
        {
            // Strange case where all tags have equal weights
            if (weightSpan == 0) return (MinimumFontSize + MaximumFontSize)/2f;
            // Convert the Weight into a 0-1 range (float)
            var weightScaled = (weight - lowestWeight)/(float) weightSpan;
            // Convert the 0-1 range into a value in the Font range.
            return MinimumFontSize + (weightScaled*fontHeightSpan);
        }

        /// <summary>
        ///   Uses the list of occupied areas to
        ///   crop the Bitmap and translates the list of occupied areas
        ///   keeping them consistant with the new cropped bitmap
        /// </summary>
        /// <param name = "cloudToCrop">The bitmap of the cloud to crop</param>
        /// <returns>The cropped version of the bitmap</returns>
        private Bitmap CropAndTranslate(Bitmap cloudToCrop)
        {
            var newTop = Occupied.Select(x => x.Top).Min() - Margin;
            var newLeft = Occupied.Select(x => x.Left).Min() - Margin;

            var bottom = Occupied.Select(x => x.Bottom).Max() + Margin;
            var right = Occupied.Select(x => x.Right).Max() + Margin;

            if (newTop < 0) newTop = 0;
            if (newLeft < 0) newLeft = 0;

            if (bottom > height) bottom = height;
            if (right > width) right = width;

            var populatedArea = new RectangleF(newLeft, newTop, right - newLeft, bottom - newTop);
            Occupied =
                Occupied.Select(it => new RectangleF(it.X - newLeft, it.Y - newTop, it.Width, it.Height)).ToList();
            return cloudToCrop.Clone(populatedArea, cloudToCrop.PixelFormat);
        }
    }

    public static class TagExtensions
    {
        public static void Rotate(this Graphics gImage, PointF about, int byAngle)
        {
            gImage.TranslateTransform(about.X, about.Y);
            gImage.RotateTransform(byAngle);
            gImage.TranslateTransform(-about.X, -about.Y);
        }

        /* Plan to use this to change strategy chosen format when it doesn't fit */

        public static StringFormat Other(this StringFormat format)
        {
            return ReferenceEquals(format, DisplayStrategy.HorizontalFormat)
                       ? DisplayStrategy.VerticalFormat
                       : DisplayStrategy.HorizontalFormat;
        }
    }
}