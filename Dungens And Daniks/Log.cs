using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dungens_And_Daniks
{
    internal class Log
    {
        FileStream Stream { get; set; }
        List<string> JsonList { get; set; }
        bool IsInit { get; set; }
        public Log() 
        {
            JsonList = new List<string>();
            IsInit = true;
            try
            {
                Stream = new FileStream("log.json", FileMode.Open);
            }catch (FileNotFoundException)
            {
                IsInit = false;
            }
        }
        public void SetCharactersFromLog()
        {
            if (IsInit)
            {

                JsonList = JsonSerializer.Deserialize<List<string>>(Stream);
              
                if (JsonList != null)
                {
                    for (int i = 0; i < JsonList.Count; i++)
                    {
                        try
                        {
                            FileStream JsonStream = new FileStream(JsonList[i], FileMode.Open);
                            DNDCharacter tmp = JsonSerializer.Deserialize<DNDCharacter>(JsonStream);
                            if (tmp != null)
                            {
                                MainMenu.CharacterList.Add(tmp);
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            continue;
                        }
                    }
                }                
            }
        }
        async public void GetLog()
        {
            if (MainMenu.CharacterList.Count != 0)
            {
                JsonList.Clear();
                foreach (DNDCharacter tmp in MainMenu.CharacterList)
                {
                    JsonList.Add(tmp.NameOfCharacter + ".json");
                }
                if (IsInit)
                { 
                    using (Stream)
                    {
                        await JsonSerializer.SerializeAsync<List<string>>(Stream, JsonList);
                    }
                }
                else
                {
                    using (FileStream newLog = new FileStream("log.json", FileMode.Create))
                    {
                        await JsonSerializer.SerializeAsync<List<string>>(newLog, JsonList);
                    }
                }
            }
            
        }
    }
}
