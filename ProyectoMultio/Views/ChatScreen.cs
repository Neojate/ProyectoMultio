using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProyectoMultio.Helper;
using ProyectoMultio.Models.Screen;
using ProyectoMultio.Modules.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Views
{
    public class ChatScreen : Screen
    {
        private Rectangle bounds { get; set; }
        private Texture2D backgroundTexture { get; set; } = Textures.BackgroundColor;
        private Texture2D borderTexture { get; set; } = Textures.BorderColor;
        private string[] text { get; set; }
        private SpriteFont font { get; set; } = Fonts.Arial14; 

        //animaciones
        private int speedAnim = 20;

        private bool doInitialAnim = true;
        private int initialHeight = 0;

        private bool doFinalAnim = false;
        private int finalHeight = 200;
        
        
        private Vector2 textPosition;
        private int countDialog;

        public ChatScreen(string[] text)
        {
            this.text = text;

            bounds = new Rectangle(100, Globals.Resolution.Y - 250, Globals.Resolution.X - 100 * 2, 200);
        }

        public override void Draw()
        {
            Globals.SpriteBatch.Draw(backgroundTexture, bounds, Color.White);
            Globals.SpriteBatch.Draw(borderTexture, new Rectangle(bounds.X, bounds.Y, bounds.Width, 3), Color.White);
            Globals.SpriteBatch.Draw(borderTexture, new Rectangle(bounds.X, bounds.Y + 200, bounds.Width, 1), Color.White);

            if (!doInitialAnim && !doFinalAnim)
            {
                textPosition = Utils.CenterText(bounds, font, text[countDialog]);
                Globals.SpriteBatch.DrawString(font, Lang.Trans(text[countDialog]), textPosition, Color.White);
            }
        }

        public override void HandleInput()
        {
            KeyboardOptions controls = Globals.Options.KeyboardOptions;
            if (Input.KeyPressed(controls.Action))
            {
                if (countDialog < text.Length - 1)
                    countDialog++;
                else
                    doFinalAnim = true;
            }


            if (Input.MouseClick(ButtonType.Left))
                if (!bounds.Contains(Input.MousePosition))
                    doFinalAnim = true;
        }

        public override void Update()
        {
            startAnimation();
            endAnimation();
        }

        private void startAnimation()
        {
            if (doInitialAnim)
            {
                initialHeight += speedAnim;
                bounds = new Rectangle(100, Globals.Resolution.Y - 250, Globals.Resolution.X - 200, initialHeight);
                doInitialAnim = initialHeight < 200;
            }
        }

        private void endAnimation()
        {
            if (doFinalAnim)
            {
                finalHeight -= speedAnim;
                if (finalHeight > 0)
                    bounds = new Rectangle(100, Globals.Resolution.Y - (50 + finalHeight), Globals.Resolution.X - 200, finalHeight);
                else
                    Globals.ScreenManager.RemoveWithFocus(this.Name, "GameScreen");
            }
        }

    }
}
