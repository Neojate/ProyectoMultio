using ProyectoMultio.Models.Character;
using ProyectoMultio.Models.Map;

namespace ProyectoMultio.Modules.Actions
{
    public interface IGrabable
    {
        void Grab(Player player, Map map);

        void Drop();
    }
}
