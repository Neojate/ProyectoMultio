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

        public void AddScreenAndFocus(Screen screen)
        {
            foreach (Screen s in screens)
                s.State = ScreenState.Hidden;
            screens.Add(screen);
        }

        /* Método estático para quitar pantallas a las actuales */
        public void RemoveScreen(string screenName)
        {
            screens.Find(s => s.Name == screenName).State = ScreenState.Shutdown;
        }

        public void RemoveWithFocus(string removeName, string focusName)
        {
            foreach (Screen screen in screens)
            {
                if (screen.Name == removeName)
                    screen.State = ScreenState.Shutdown;
                else if (screen.Name == focusName)
                    screen.State = ScreenState.Active;
            }
        }

        public void Update()
        {
            List<Screen> removeScreens = new List<Screen>();

            foreach (Screen screen in screens)
                if (screen.State == ScreenState.Shutdown)
                    removeScreens.Add(screen);

            foreach (Screen screen in removeScreens)
                screens.Remove(screen);

            foreach (Screen screen in screens.FindAll(s => s.State == ScreenState.Active).ToArray())
            {
                screen.HandleInput();
                screen.Update();
            }
        }

        public void Draw()
        {
            foreach (Screen screen in screens.FindAll(s => s.State != ScreenState.Shutdown))
                screen.Draw();
        }

    }
}
