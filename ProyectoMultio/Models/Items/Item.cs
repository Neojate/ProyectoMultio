using ProyectoMultio.Models.Character;
using ProyectoMultio.Models.Maps;
using ProyectoMultio.Modules.Verbs;
using System.Collections.Generic;

namespace ProyectoMultio.Models.Items
{
    public class Item : Element, IGrabable, IContextualizable
    {
        public bool IsAnItem { get; set; } = true;
        private Player player;
        private Map map;
        public Item(Map map, Player player)
        {
            IsBlock = false;
            this.player = player;
            this.map = map;
        }

        public void Drop()
        {
            throw new System.NotImplementedException();
        }

        public void Grab()
        {
            player.CharacterSheet.Inventory.Add(this);
            map.Elements.Remove(this);
        }

        public List<Contextual> ContextualizeMethods()
        {
            return new List<Contextual>()
            {
                new Contextual("Grab", true)
            };
        }
    }
}
