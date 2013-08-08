using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NewUserAdds.Classes
{
    /// <summary>
    /// Standard Progress Bar that can have a string overlayed on the meter.
    /// </summary>
    public class StatusOverlayProgressBar : ProgressBar
    {

        private string _message;
        /// <summary>
        /// [Optional] Message to overlay on the status bar. Defaults to "[Value]/[Maximum]"
        /// </summary>
        public string Message
        {
            get 
            { 
                if(String.IsNullOrEmpty(_message))
                    return this.Value.ToString() + '/' + this.Maximum.ToString();
                else
                    return _message; 
            }
            set { _message = value; }
        }

        private FontFamily _fontFamily;
        /// <summary>
        /// [Optional] Typeface for the Overlay. Defaults to Arial Unicode MS
        /// </summary>
        public string Font_Face
        {
            get { return _fontFamily.Name; }
            set
            {
                _fontFamily = FontFamily.Families.ToList<FontFamily>().Find(f => String.Compare(f.Name, value.ToString(), true) == 0);
                if (_fontFamily == null) throw new System.ArgumentNullException("Named FontFamily doesn't exist");
            }
        }

        private int _fontSize;
        /// <summary>
        /// [Optional] Size of the Overlay font. Defaults to 8
        /// </summary>
        public int Font_Size
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }

        private FontStyle _fontStyle;
        /// <summary>
        /// [Optional] Style of the Overlay font. Defaults to Regular
        /// </summary>
        public FontStyle Font_Style
        {
            get { return _fontStyle; }
            set { _fontStyle = value; }
        }

        private Font _font = null;
        /// <summary>
        /// [Optional] Font to use for the Overlay. Defaults to values set in Font_Face, Font_Size, and Font_Style
        /// </summary>
        public Font Overlay_Font
        {
            get 
            {
                if (_font != null)
                    return _font;
                else
                    return new Font(_fontFamily, _fontSize, _fontStyle);
            }
            set { _font = value; }
        }

        private Brush _fontColor = Brushes.Black;
        /// <summary>
        /// [Optional] Color for the Overlay font. Defaults to black.
        /// </summary>
        public Brush Font_Color
        {
            get
            {
                if (_fontColor != null)
                    return _fontColor;
                else
                    return Brushes.Black;
            }

            set { _fontColor = value; }
        }

        /// <summary>
        /// New StatusOverlayProgressBar Object.
        /// Default string font is 8pt Arial Unicode MS.
        /// Default message is [Completed]/[Total]
        /// </summary>
        public StatusOverlayProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            Font_Face = "Arial Unicode MS";
            _fontSize = 8;
            _fontStyle = FontStyle.Regular;
        }

        /// <summary>
        /// New StatusOverlayProgressBar Object.
        /// Default string font is 8pt Arial Unicode MS.
        /// </summary>
        /// <param name="message">Custom message to display on object creation. This will need to be updated manually as the status changes</param>
        public StatusOverlayProgressBar(string message)
            : this()
        {
            _message = message;
        }

        /// <summary>
        /// Overridden from ProgressBar.OnPaint() event to draw the overlayed message
        /// </summary>
        /// <param name="e">Automatically sent arguments</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;
            Graphics gfx = e.Graphics;

            if(Application.RenderWithVisualStyles)
            {
                // Fill in the progress part, scaled down so we still have the border
                ProgressBarRenderer.DrawHorizontalBar(gfx, rect);
            } else 
            {
                gfx.FillRectangle(new SolidBrush(Color.LightGray), rect);
            }


            rect.Inflate(-2, -2);

            // Only draw the status bar if the Value of the ProgressBar is more than 0. If the value is 0, there isn't any progress to show anyway.
            if (this.Value > 0)
            {
                // X & Y are the coords for the upper left corner. Height is the height.
                // Width of the status part is the percentage complete (value/max) applied to the available width.
                // i.e. if the statis is 20% done, fill 20% of the width of the bar.
                Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)this.Value / this.Maximum) * rect.Width), rect.Height);
                if (Application.RenderWithVisualStyles)
                {
                    ProgressBarRenderer.DrawHorizontalChunks(gfx, clip);
                }
                else
                {
                    gfx.FillRectangle(new SolidBrush(Color.Blue), clip);
                }
            }

            // Draw the overlayed message
            using (Font f = this.Overlay_Font)
            {
                SizeF strLen = gfx.MeasureString(_message, f);

                //Location is the upper-left corner of the Message rectangle, as drawn with the defined font (graphics always start in the upper left corner)
                // Width => 1/2 the bar width - 1/2 the overlay width. That offsets the overlay so the centerlines of both the overlay and the bar align - centering the text.
                Point location = new Point((int)((rect.Width / 2) - (strLen.Width / 2)), (int)((rect.Height / 2) - (strLen.Height / 2)) + 3);
                gfx.DrawString(_message, f, this.Font_Color, location);
            }
        }

    }
}
