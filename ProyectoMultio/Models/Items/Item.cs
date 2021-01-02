using ProyectoMultio.Models.Character;
using ProyectoMultio.Models.Elements;
using ProyectoMultio.Modules.Actions;
using System.Collections.Generic;

namespace ProyectoMultio.Models.Items
{
    public class Item : Element, IGrabable, IContextualizable
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

        public List<string> ContextualizeMethods()
        {
            return new List<string>() { "Grab" };
        }
    }
}
