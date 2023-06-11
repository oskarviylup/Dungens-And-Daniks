using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace Dungens_And_Daniks
{
    class MainMenu
    {
        static void Main()
        {
            Console.WriteLine("\r\n██████╗░██╗░░░██╗███╗░░██╗░██████╗░███████╗███╗░░██╗░██████╗  ░█████╗░███╗░░██╗██████╗░\r\n██╔══██╗██║░░░██║████╗░██║██╔════╝░██╔════╝████╗░██║██╔════╝  ██╔══██╗████╗░██║██╔══██╗\r\n██║░░██║██║░░░██║██╔██╗██║██║░░██╗░█████╗░░██╔██╗██║╚█████╗░  ███████║██╔██╗██║██║░░██║\r\n██║░░██║██║░░░██║██║╚████║██║░░╚██╗██╔══╝░░██║╚████║░╚═══██╗  ██╔══██║██║╚████║██║░░██║\r\n██████╔╝╚██████╔╝██║░╚███║╚██████╔╝███████╗██║░╚███║██████╔╝  ██║░░██║██║░╚███║██████╔╝\r\n╚═════╝░░╚═════╝░╚═╝░░╚══╝░╚═════╝░╚══════╝╚═╝░░╚══╝╚═════╝░  ╚═╝░░╚═╝╚═╝░░╚══╝╚═════╝░\r\n\r\n██████╗░░█████╗░███╗░░██╗██╗██╗░░██╗░██████╗\r\n██╔══██╗██╔══██╗████╗░██║██║██║░██╔╝██╔════╝\r\n██║░░██║███████║██╔██╗██║██║█████═╝░╚█████╗░\r\n██║░░██║██╔══██║██║╚████║██║██╔═██╗░░╚═══██╗\r\n██████╔╝██║░░██║██║░╚███║██║██║░╚██╗██████╔╝\r\n╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═╝╚═╝░░╚═╝╚═════╝░");
        
            DNDCharacter test = new DNDCharacter();
            test.SaveCharacter();
            Console.ReadKey();
        }
    }
}
