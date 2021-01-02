using Microsoft.Xna.Framework;
using ProyectoMultio.Helper;
using ProyectoMultio.Models.Components;
using ProyectoMultio.Models.Elements;
using ProyectoMultio.Models.Screen;
using ProyectoMultio.Modules.Actions;
using System.Collections.Generic;

namespace ProyectoMultio.Views
{
    public class ContextualScreen : Screen
    {
        private Rectangle bounds;

        private List<ContextualButton> buttons = new List<ContextualButton>();

        public ContextualScreen(Element element, Point initialPosition)
        {
            bounds = new Rectangle(initialPosition.X, initialPosition.Y, 200, 300);

            int yCoord = initialPosition.Y;
            int yCoordIncrement = 30;
            foreach (string nameMethod in ((IContextualizable)element).ContextualizeMethods())
            {
                ContextualButton button = new ContextualButton()
                { 
                    Bounds = new Rectangle(initialPosition.X, yCoord, 200, yCoordIncrement),
                    SourceRectangle = new Rectangle(0, 0, 1, 1),
                    NameMethod = nameMethod,
                    Element = element
                };
                buttons.Add(button);
            }
        }

        public override void Draw()
        {
            Globals.SpriteBatch.Draw(Textures.Another, bounds, new Rectangle(0, 0, 1, 1), Color.White);
            
            foreach (IRenderizable component in buttons)
                component.Render(null);
        }

        public override void HandleInput()
        {
            if (Input.MouseClick(ButtonType.Left))
            {
                if (!bounds.Contains(Input.MousePosition))
                    Globals.ScreenManager.RemoveWithFocus(this.Name, "GameScreen");

                buttons.ForEach(button => button.onClick());
            }
        }

        public override void Update()
        {
            buttons.ForEach(button => button.onHover());
        }
    }
}
