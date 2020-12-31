using ProyectoMultio.Models.Screen;
using System.Collections.Generic;

namespace ProyectoMultio.Modules.ScreenManagers
{
    public class ScreenManager
    {
        private List<Screen> screens { get; } = new List<Screen>();

        /* Método estático para añadir pantallas a las actuales */
        public void AddScreen(Screen screen)
        {
            screens.Add(screen);
        }

        /* Método estático para quitar pantallas a las actuales */
        public void Unload(string screenName)
        {
            screens.Find(s => s.Name == screenName).State = ScreenState.Shutdown;
        }

        public void Update()
        {
            List<Screen> removeScreens = new List<Screen>();

            foreach (Screen screen in screens)
                if (screen.State == ScreenState.Shutdown)
                    removeScreens.Add(screen);

            foreach (Screen screen in removeScreens)
                screens.Remove(screen);

            screens.ForEach(screen =>
            {
                screen.HandleInput();
                screen.Update();
            });

        }

        public void Draw()
        {
            foreach (Screen screen in screens)
                if (screen.State == ScreenState.Active)
                    screen.Draw();
        }

    }
}
