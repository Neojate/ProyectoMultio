using Microsoft.Xna.Framework;
using ProyectoMultio.Helper;
using ProyectoMultio.Models.Components;
using ProyectoMultio.Models.Screen;
using ProyectoMultio.Modules.Options;
using System.Collections.Generic;

namespace ProyectoMultio.Views
{
    class InventoryScreen : Screen
    {
        private List<Panel> panels;

        public InventoryScreen()
        {
            panels = new List<Panel>()
            {
                new Panel()
                {
                    Texture = Textures.InventoryBg,
                    Bounds = new Rectangle(0, 0, Globals.Resolution.X, Globals.Resolution.Y),
                    SourceRectangle = new Rectangle(0, 0, Textures.InventoryBg.Width, Textures.InventoryBg.Height),
                    BackgroundColor = Color.Yellow,
                    Style = new Style()
                    {
                        Margin = new int[] { 100, 100, 100, 100 }
                    }
                }
            };
        }

        public override void Draw()
        {
            foreach (Panel panel in panels)
                panel.Render();
        }

        public override void HandleInput()
        {
            KeyboardOptions controls = Globals.Options.KeyboardOptions;

            if (Input.KeyPressed(controls.Inventory))
                Globals.ScreenManager.RemoveWithFocus(this.Name, "GameScreen");
        }

        public override void Update()
        {
            
        }
    }
}
