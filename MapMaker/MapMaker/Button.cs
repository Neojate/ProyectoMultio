using MapMaker.Actions;
using MapMaker.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MapMaker.MapMaker
{
    public class Button : UIElement, IClickable
    {
        //Texto del botón
        public String Text { get; set; }

        //Fuente que utiliza la letra del botón
        public SpriteFont Font { get; set; } = Fonts.Arial_12;

        //Color que utiliza el texto del botón
        public Color FontColor { get; set; } = Color.Black;

        public Click ActionClick;

        private Point? coordinatesText;

        public virtual void onClick(Point mousePosition)
        {
            if (Bounds.Contains(mousePosition))
                ActionClick();
        }

        public virtual void onHover(Point mousePosition)
        {
            BackgroundColor = Bounds.Contains(mousePosition) ? Color.Gray : Color.White;
        }

        public override void Render()
        {
            Globals.SpriteBatch.Draw(Texture, Bounds, SourceRectangle, BackgroundColor);
            if (Text != null)
            {
                if (coordinatesText == null)
                {
                    resizeButton();
                    coordinatesText = getCoordinatesText();
                }
                Globals.SpriteBatch.DrawString(Font, Text, new Vector2(coordinatesText.Value.X, coordinatesText.Value.Y), FontColor);
            }
        }

        public delegate void Click();

        private Point getCoordinatesText()
        {
            if (Text == null)
                return new Point(Bounds.X, Bounds.Y);

            return Utils.CenterText(Font, Text, Bounds);
        }

        private void resizeButton()
        {
            if (Text == null)
                return;
            
            Point size = new Point(Bounds.Width, Bounds.Height);
            Vector2 measureText = Font.MeasureString(Text);
            
            if (measureText.X > Bounds.Width)
                size.X = (int)measureText.X;

            if (measureText.Y > Bounds.Height)
                size.Y = (int)measureText.Y;

            Bounds = new Rectangle(Bounds.X, Bounds.Y, size.X, size.Y);
        }
    }
}
