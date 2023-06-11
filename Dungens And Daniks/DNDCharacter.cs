using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace Dungens_And_Daniks
{
    
    internal class DNDCharacter
    {   
        public string NameOfCharacter { get; set; }
        public int Level { get; set; }
        public string Class { get; set; }
        public string Origin { get; set; }
        public List<Spell> Spells { get; set; }
        public string Race { get; set; }
        public string Ideology { get; set; }
        public string PersonTraits { get; set; }
        public string Ideals { get; set; }
        public string Bonds { get; set; }
        public string Defects { get; set; }
        public string History { get; set; }
        public int HealthDice { get; set; }
        public List<string> Languages { get; set; }

        public DNDCharacter()
        {
            Spells = new List<Spell>();
            Languages = new List<string>();
            NameOfCharacter = "Unknown";
            Level = 0;
            HealthDice = 0;
            Class = "???";
            Origin = "???";
            Race = "???";
            Ideology = "???";
            PersonTraits = "???";
            Ideals = "???";
            Bonds = "???";
            Defects = "???";
            History = "???";
        }
        public string GetJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public async void SaveCharacter()
        {
            StringBuilder jsonName = new StringBuilder();
            jsonName.Append(NameOfCharacter);
            jsonName.Append(".json");
            using (FileStream fs = new FileStream(jsonName.ToString(), FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<DNDCharacter>(fs, this);
            }
        }
    }
}
