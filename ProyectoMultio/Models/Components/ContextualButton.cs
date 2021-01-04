using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProyectoMultio.Helper;
using ProyectoMultio.Models.Cameras;
using ProyectoMultio.Modules.Actions;

namespace ProyectoMultio.Models.Components
{
    public class ContextualButton : Component, IClickable
    {
        public string NameMethod { get; set; } = "";
        public SpriteFont Font { get; set; } = Fonts.Arial8;
        public Color FontColor { get; set; } = Color.Black;
        public Element Element { get; set; }

        public ContextualButton()
        {
            Texture = Textures.Another;
        }

        public void onClick()
        {
            if (Bounds.Contains(Input.MousePosition))
                Element.GetType().GetMethod(NameMethod).Invoke(Element, null);
        }

        public void onHover()
        {
            if (Bounds.Contains(Input.MousePosition))
            {
                BackgroundColor = Color.Gray;
                FontColor = Color.White;
            }
            else
            {
                BackgroundColor = Color.White;
                FontColor = Color.Black;
            }

        }

        public override void Render(Camera camera)
        {
            Globals.SpriteBatch.Draw(Texture, Bounds, SourceRectangle, BackgroundColor);

            Vector2 textPos = Utils.CenterText(Bounds, Font, NameMethod);
            Globals.SpriteBatch.DrawString(Font, Lang.Trans(NameMethod), textPos, FontColor);
        }

        
    }
}
