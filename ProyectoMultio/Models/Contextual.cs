using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Models
{
    public class Contextual
    {
        // Nombre que se muestra por pantalla en los menús. Requiere que sea traducido por el lang.
        public string VisibleName { get; set; }

        // Nombre del método al que se llama al interactuar con él.
        public string NameMethod { get; set; }

        // Indica si este método es utilizable dentro de GameScreen.
        public bool CanUseOnMap { get; set; }

        public Contextual(string visibleName, string nameMethod, bool canUseOnMap)
        {
            VisibleName = visibleName;
            NameMethod = nameMethod;
            CanUseOnMap = canUseOnMap;
        }
    }
}
