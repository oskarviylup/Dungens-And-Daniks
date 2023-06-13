using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungens_And_Daniks
{
    internal enum TypeOfSpell
    {
        Hil = 1,
        Defence = 2,
        Attack = 3,
        Passive = 4,
        Empty = 0
    }
    internal enum CastType
    {
        AOE = 1,
        Target = 2,
        Empty = 0
    }
    internal class Spell
    {
        public string NameOfSpell { get; set; }
        public TypeOfSpell Type { get; set; }

        public CastType Cast { get; set; }

        public int Range { get; set; }

        public string Description { get; set; }

        public Spell()
        {
            NameOfSpell = "???";
            Type = TypeOfSpell.Empty;
            Cast = CastType.Empty;
            Range = 0;
            Description = "???";
        }
    }
}
