using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Modules.Options
{
    public class Options
    {
        public KeyboardOptions KeyboardOptions { get; set; }

        public Options()
        {
            KeyboardOptions = new KeyboardOptions();
        }
    }
}
