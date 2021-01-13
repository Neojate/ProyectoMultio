using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProyectoMultio.Helper;
using ProyectoMultio.Modules.Verbs;

namespace ProyectoMultio.Models.Components
{
    public class ContextualButton : Component, IClickable
    {
        public string NameMethod { get; set; } = "";
        public SpriteFont Font { get; set; } = Fonts.Arial14;
        public Color FontColor { get; set; } = Color.Black;
        public Element Element { get; set; }

        public bool IsActive { get; set; } = true;

        public ContextualButton()
        {
            Texture = Textures.Another;
        }

        public void onClick()
        {
            if (IsActive && Bounds.Contains(Input.MousePosition))
                Element.GetType().GetMethod(NameMethod).Invoke(Element, null);
        }

        public void onHover()
        {
            if (!IsActive)
                return;

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

        public override void Render()
        {
            Globals.SpriteBatch.Draw(Texture, Bounds, SourceRectangle, BackgroundColor);

            Vector2 textPos = Utils.CenterText(Bounds, Font, NameMethod);
            Globals.SpriteBatch.DrawString(Font, Lang.Trans(NameMethod), textPos, FontColor);
        }

        
    }
}
