using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungens_And_Daniks
{
    internal class Stats
    {
        public Tuple<int, int> Strength { get; set; }    
        public Tuple<int, int> Agility { get; set; }
        public Tuple<int, int> Stamina { get; set; }
        public Tuple<int, int> Intelligence { get; set; }
        public Tuple<int, int> Wisdom { get; set; }
        public Tuple <int, int> Charisma { get; set; }
        public int SkillBonus { get; set; }

        public Stats() 
        {
            Strength = new Tuple<int, int>(0, 0);
            Agility = new Tuple<int, int>(0, 0);
            Stamina = new Tuple<int, int>(0, 0);
            Intelligence = new Tuple<int, int>(0, 0);
            Wisdom = new Tuple<int, int>(0, 0);
            Charisma = new Tuple<int, int>(0, 0);
            SkillBonus = 0;
        }
    }
}
