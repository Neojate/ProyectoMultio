using ProyectoMultio.Helper;
using ProyectoMultio.Modules.Verbs;
using ProyectoMultio.Views;

namespace ProyectoMultio.Models.Npcs
{
    public class Allied : Npc, IUsable
    {
        public string[] Conversation { get; set; }

        public void Use()
        {
            Globals.ScreenManager.AddScreenAndFocus(new ChatScreen(Conversation));
        }
    }
}
