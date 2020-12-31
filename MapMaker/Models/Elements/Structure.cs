using JsonSubTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker.Models.Elements
{
    public class Structure : MapElement
    {
        public bool IsBlock { get; set; } = true;
    }
}
