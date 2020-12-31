using ProyectoMultio.Models.Character;
using ProyectoMultio.Models.Elements;
using ProyectoMultio.Modules.Actions;

namespace ProyectoMultio.Models.Items
{
    public class Item : Element, IGrabable
    {
        public bool IsAnItem { get; set; } = true;
        public Item()
        {
            IsBlock = false;
        }

        public void Drop()
        {
            throw new System.NotImplementedException();
        }

        public void Grab(Player player, Map.Map map)
        {
            player.CharacterSheet.Inventory.Add(this);
            map.Elements.Remove(this);
        }
    }
}
