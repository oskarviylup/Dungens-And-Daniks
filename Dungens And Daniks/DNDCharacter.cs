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
        public int Gold { get; set; }
        public int HP { get; set; }
        public int CurrentHP { get; set; }
        public int Armor { get; set; } 
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
        public Stats StatsOfCharacter { get; set; }
        public List<Item> Items { get; set; }
        public bool DeathDice { get; set; }
        public DNDCharacter()
        {
            Spells = new List<Spell>();
            Languages = new List<string>();
            Items = new List<Item>();
            NameOfCharacter = "Unknown";
            Class = "???";
            Origin = "???";
            Race = "???";
            Ideology = "???";
            PersonTraits = "???";
            Ideals = "???";
            Bonds = "???";
            Defects = "???";
            History = "???";
            StatsOfCharacter = new Stats();
            Gold = Level = HealthDice = Armor = HP = CurrentHP = 0;
            DeathDice = true;
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
