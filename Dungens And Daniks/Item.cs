using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungens_And_Daniks
{
    internal class Item
    {
        public string Name { get; set; }  
        public string Description { get; set; }
        public Item() 
        { 
            Name = "???";
            Description = "???";
        }
    }
}
