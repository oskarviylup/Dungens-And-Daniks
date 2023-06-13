using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Xml;

namespace Dungens_And_Daniks
{
    internal class MainMenu
    {
        internal static List<DNDCharacter> CharacterList { get; set; } 
        internal static Log log {get; set;}
        public static void SaveChanges()
        {
            foreach (var character in CharacterList)
            {
                character.SaveCharacter();
            }
            log.GetLog();
        }
        public static void CreateCharacterMenu()
        {
            DNDCharacter NewCharacter = new DNDCharacter();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine(
                "\r\n▒█▀▀█ ▒█▀▀█ ▒█▀▀▀ ░█▀▀█ ▀▀█▀▀ ▒█▀▀▀   ▒█░░▒█ ▒█▀▀▀█ ▒█░▒█ ▒█▀▀█   ▒█▀▀▄ ▒█▀▀▀ ▒█▀▀▀█ ▀▀█▀▀ ▀█▀ ▒█▄░▒█ ▒█░░▒█ " +
                "\r\n▒█░░░ ▒█▄▄▀ ▒█▀▀▀ ▒█▄▄█ ░▒█░░ ▒█▀▀▀   ▒█▄▄▄█ ▒█░░▒█ ▒█░▒█ ▒█▄▄▀   ▒█░▒█ ▒█▀▀▀ ░▀▀▀▄▄ ░▒█░░ ▒█░ ▒█▒█▒█ ▒█▄▄▄█ " +
                "\r\n▒█▄▄█ ▒█░▒█ ▒█▄▄▄ ▒█░▒█ ░▒█░░ ▒█▄▄▄   ░░▒█░░ ▒█▄▄▄█ ░▀▄▄▀ ▒█░▒█   ▒█▄▄▀ ▒█▄▄▄ ▒█▄▄▄█ ░▒█░░ ▄█▄ ▒█░░▀█ ░░▒█░░");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Текст вводить в строку, подтверждение с помощью кнопки ENTER\n");
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("Введите имя персонажа");
            string tmp = Console.ReadLine();
            Console.WriteLine();
            NewCharacter.NameOfCharacter = tmp;
            Console.WriteLine("Введите класс");
            tmp = Console.ReadLine();
            Console.WriteLine();
            NewCharacter.Class = tmp;
            Console.WriteLine("Введите уровень (целое положительное число)");
            tmp = Console.ReadLine(); Console.WriteLine();
            NewCharacter.Level = int.Parse(tmp);
            Console.WriteLine("Напишите здоровье персонажа (целое положительное число)");
            tmp = Console.ReadLine(); Console.WriteLine();
            NewCharacter.HP = NewCharacter.CurrentHP = int.Parse(tmp);
            Console.WriteLine("Напишите броню персонажа (целое положительное число)");
            tmp = Console.ReadLine(); Console.WriteLine();
            NewCharacter.Armor = int.Parse(tmp);
            Console.WriteLine("Введите расу");
            tmp = Console.ReadLine(); Console.WriteLine();
            NewCharacter.Race = tmp;
            Console.WriteLine("Напишите проихождение");
            tmp = Console.ReadLine(); Console.WriteLine();
            NewCharacter.Origin = tmp;
            Console.WriteLine("Напишите мировоззрение");
            tmp = Console.ReadLine(); Console.WriteLine();
            NewCharacter.Ideology = tmp;
            Console.WriteLine("Напишите свойства личности");
            tmp = Console.ReadLine(); Console.WriteLine();
            NewCharacter.PersonTraits = tmp;
            Console.WriteLine("Напишите идеалы персонажа");
            tmp = Console.ReadLine(); Console.WriteLine();
            NewCharacter.Ideals = tmp;
            Console.WriteLine("Напишите узы персонажа");
            tmp = Console.ReadLine(); Console.WriteLine();
            NewCharacter.Bonds = tmp;
            Console.WriteLine("Напишите изъяны персонажа");
            tmp = Console.ReadLine(); Console.WriteLine();
            NewCharacter.Defects = tmp;
            Console.WriteLine("Напишите историю персонажа");
            tmp = Console.ReadLine(); Console.WriteLine();
            NewCharacter.History = tmp;
            Console.WriteLine("Введите кубики здоровья (целое положительное число)");
            tmp = Console.ReadLine(); Console.WriteLine();
            NewCharacter.HealthDice = int.Parse(tmp);
            Console.WriteLine("У персонажа имеются кубики со смертью?(1 - да, 0 - нет)");
            if(Console.ReadLine() == "1")
            {
                NewCharacter.DeathDice = true;
            }
            else
            {
                NewCharacter.DeathDice = false;
            }
            Console.WriteLine();
            Console.WriteLine("Введите количество языков, которыми обладает персонаж (целое положительное число)");
            int n = int.Parse(Console.ReadLine()); Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Напишите язык");
                tmp = Console.ReadLine(); Console.WriteLine();
                NewCharacter.Languages.Add(tmp);
            }
            Console.WriteLine("Введите количество способностей персонажа (целое положительное число)");
            n = int.Parse(Console.ReadLine()); Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Spell spell = new Spell();
                Console.WriteLine("Напишите название способности");
                tmp = Console.ReadLine(); Console.WriteLine();
                spell.NameOfSpell = tmp;
                Console.WriteLine("Введите тип способности\n" +
                    "1 - Лечащая\n" +
                    "2 - Защитная\n" +
                    "3 - Атакующая\n" +
                    "4 - Пассивная\n");
                spell.Type = (TypeOfSpell)int.Parse(Console.ReadLine()); Console.WriteLine();
                Console.WriteLine("Введите тип применения способности\n" +
                    "1 - По площади\n" +
                    "2 - Точечная\n" +
                    "0 - Не имеет области применения\n");
                spell.Cast = (CastType)int.Parse(Console.ReadLine()); Console.WriteLine();
                Console.WriteLine("Введите дальность применения в футах (целое положительное число)");
                tmp = Console.ReadLine(); Console.WriteLine();
                spell.Range = int.Parse(tmp);
                Console.WriteLine("Напишите описание способности");
                tmp = Console.ReadLine(); Console.WriteLine();
                spell.Description = tmp;
                NewCharacter.Spells.Add(spell);
            }
            Console.WriteLine("Введите количество предметов персонажа (целое положительное число)");
            n = int.Parse(Console.ReadLine()); Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Item item = new Item();
                Console.WriteLine("Напишите название предмета");
                tmp = Console.ReadLine(); Console.WriteLine();
                item.Name = tmp;
                Console.WriteLine("Напишите описание предмета");
                tmp = Console.ReadLine(); Console.WriteLine();
                item.Description = tmp;
                NewCharacter.Items.Add(item);
            }
            Console.WriteLine("Введите силу персонажа (целое положительное число)");
            int tmp1 = int.Parse(Console.ReadLine()); Console.WriteLine();
            Console.WriteLine("Введите бонус силы (целое число)");
            int tmp2 = int.Parse(Console.ReadLine()); Console.WriteLine();
            NewCharacter.StatsOfCharacter.Strength = new Tuple<int, int>(tmp1, tmp2);

            Console.WriteLine("Введите ловкость персонажа (целое положительное число)");
            tmp1 = int.Parse(Console.ReadLine()); Console.WriteLine();
            Console.WriteLine("Введите бонус ловкости (целое число)");
            tmp2 = int.Parse(Console.ReadLine()); Console.WriteLine();
            NewCharacter.StatsOfCharacter.Agility = new Tuple<int, int>(tmp1, tmp2);

            Console.WriteLine("Введите выносливость персонажа (целое положительное число)");
            tmp1 = int.Parse(Console.ReadLine()); Console.WriteLine();
            Console.WriteLine("Введите бонус выносливости (целое число)");
            tmp2 = int.Parse(Console.ReadLine()); Console.WriteLine();
            NewCharacter.StatsOfCharacter.Stamina = new Tuple<int, int>(tmp1, tmp2);

            Console.WriteLine("Введите интеллект персонажа (целое положительное число)");
            tmp1 = int.Parse(Console.ReadLine()); Console.WriteLine();
            Console.WriteLine("Введите бонус интеллекта (целое число)");
            tmp2 = int.Parse(Console.ReadLine()); Console.WriteLine();
            NewCharacter.StatsOfCharacter.Intelligence = new Tuple<int, int>(tmp1, tmp2);

            Console.WriteLine("Введите мудрость персонажа (целое положительное число)");
            tmp1 = int.Parse(Console.ReadLine()); Console.WriteLine();
            Console.WriteLine("Введите бонус мудрости (целое число)");
            tmp2 = int.Parse(Console.ReadLine()); Console.WriteLine();
            NewCharacter.StatsOfCharacter.Wisdom = new Tuple<int, int>(tmp1, tmp2);

            Console.WriteLine("Введите харизму персонажа (целое положительное число)");
            tmp1 = int.Parse(Console.ReadLine()); Console.WriteLine();
            Console.WriteLine("Введите бонус харизмы (целое число)");
            tmp2 = int.Parse(Console.ReadLine()); Console.WriteLine();
            NewCharacter.StatsOfCharacter.Charisma = new Tuple<int, int>(tmp1, tmp2);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(
                "\r\n▒█▀▀█ ▒█▀▀█ ▒█▀▀▀ ▒█▀▀▀█ ▒█▀▀▀█   ▒█▀▀▀ ▒█▄░▒█ ▀▀█▀▀ ▒█▀▀▀ ▒█▀▀█   ▀▀█▀▀ ▒█▀▀▀█   ▒█▀▀▀ ▀█▀ ▒█▄░▒█ ▀█▀ ▒█▀▀▀█ ▒█░▒█ " +
                "\r\n▒█▄▄█ ▒█▄▄▀ ▒█▀▀▀ ░▀▀▀▄▄ ░▀▀▀▄▄   ▒█▀▀▀ ▒█▒█▒█ ░▒█░░ ▒█▀▀▀ ▒█▄▄▀   ░▒█░░ ▒█░░▒█   ▒█▀▀▀ ▒█░ ▒█▒█▒█ ▒█░ ░▀▀▀▄▄ ▒█▀▀█ " +
                "\r\n▒█░░░ ▒█░▒█ ▒█▄▄▄ ▒█▄▄▄█ ▒█▄▄▄█   ▒█▄▄▄ ▒█░░▀█ ░▒█░░ ▒█▄▄▄ ▒█░▒█   ░▒█░░ ▒█▄▄▄█   ▒█░░░ ▄█▄ ▒█░░▀█ ▄█▄ ▒█▄▄▄█ ▒█░▒█");
            CharacterList.Add(NewCharacter);
            Console.ReadKey(true);
        }
        public static void CharacterMenu()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine(
                    "\r\n▒█▀▀█ ▒█░▒█ ░█▀▀█ ▒█▀▀█ ░█▀▀█ ▒█▀▀█ ▀▀█▀▀ ▒█▀▀▀ ▒█▀▀█ ▒█▀▀▀█ " +
                    "\r\n▒█░░░ ▒█▀▀█ ▒█▄▄█ ▒█▄▄▀ ▒█▄▄█ ▒█░░░ ░▒█░░ ▒█▀▀▀ ▒█▄▄▀ ░▀▀▀▄▄ " +
                    "\r\n▒█▄▄█ ▒█░▒█ ▒█░▒█ ▒█░▒█ ▒█░▒█ ▒█▄▄█ ░▒█░░ ▒█▄▄▄ ▒█░▒█ ▒█▄▄▄█\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("(С) - Создание персонажа");
                Console.WriteLine("(R) - Редактирование персонажей");
                Console.WriteLine("(S) - Сохранить изменения");
                Console.WriteLine("(E) - Выход в главное меню");
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.C)
                {
                    CreateCharacterMenu();
                }
                else if (key.Key == ConsoleKey.R)
                {

                }
                else if (key.Key == ConsoleKey.S)
                {
                    SaveChanges();
                }
                else if (key.Key == ConsoleKey.E)
                {
                    MMenu();
                }
            }
            
        }
        static public void StartMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(
                "\r\n██████╗░██╗░░░██╗███╗░░██╗░██████╗░███████╗███╗░░██╗░██████╗  ░█████╗░███╗░░██╗██████╗░\r\n" +
                "██╔══██╗██║░░░██║████╗░██║██╔════╝░██╔════╝████╗░██║██╔════╝  ██╔══██╗████╗░██║██╔══██╗\r\n" +
                "██║░░██║██║░░░██║██╔██╗██║██║░░██╗░█████╗░░██╔██╗██║╚█████╗░  ███████║██╔██╗██║██║░░██║\r\n" +
                "██║░░██║██║░░░██║██║╚████║██║░░╚██╗██╔══╝░░██║╚████║░╚═══██╗  ██╔══██║██║╚████║██║░░██║\r\n" +
                "██████╔╝╚██████╔╝██║░╚███║╚██████╔╝███████╗██║░╚███║██████╔╝  ██║░░██║██║░╚███║██████╔╝\r\n" +
                "╚═════╝░░╚═════╝░╚═╝░░╚══╝░╚═════╝░╚══════╝╚═╝░░╚══╝╚═════╝░  ╚═╝░░╚═╝╚═╝░░╚══╝╚═════╝░\r\n" +
                "\r\n██████╗░░█████╗░███╗░░██╗██╗██╗░░██╗░██████╗\r" +
                "\n██╔══██╗██╔══██╗████╗░██║██║██║░██╔╝██╔════╝\r\n" +
                "██║░░██║███████║██╔██╗██║██║█████═╝░╚█████╗░\r\n" +
                "██║░░██║██╔══██║██║╚████║██║██╔═██╗░░╚═══██╗\r\n" +
                "██████╔╝██║░░██║██║░╚███║██║██║░╚██╗██████╔╝\r\n" +
                "╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═╝╚═╝░░╚═╝╚═════╝░\n");
            Console.WriteLine("" +
                "\r\n█▀▀▄ █░░█   ▒█░▄▀ █▀▀█ █▀▀█ █▀▀▄ █▀▀█ █▀▀▄ " +
                "\r\n█▀▀▄ █▄▄█   ▒█▀▄░ █▄▄█ █▄▄▀ █░░█ █▄▄█ █░░█ " +
                "\r\n▀▀▀░ ▄▄▄█   ▒█░▒█ ▀░░▀ ▀░▀▀ ▀▀▀░ ▀░░▀ ▀░░▀");
            if(CharacterList.Count > 0)
            {
                Console.WriteLine("da");
            }
            Console.ReadKey();
            MMenu();
        }
        public static void MMenu()
        {
            while (true)
            {
                Console.ForegroundColor
                = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine(
                    "\r\n▒█▀▄▀█ ░█▀▀█ ▀█▀ ▒█▄░▒█   ▒█▀▄▀█ ▒█▀▀▀ ▒█▄░▒█ ▒█░▒█ " +
                    "\r\n▒█▒█▒█ ▒█▄▄█ ▒█░ ▒█▒█▒█   ▒█▒█▒█ ▒█▀▀▀ ▒█▒█▒█ ▒█░▒█ " +
                    "\r\n▒█░░▒█ ▒█░▒█ ▄█▄ ▒█░░▀█   ▒█░░▒█ ▒█▄▄▄ ▒█░░▀█ ░▀▄▄▀\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("(С) - Персонажи");
                Console.WriteLine("(F) - Бой");
                Console.WriteLine("(S) - Сохранить изменения");
                Console.WriteLine("(ESC) - Выход из программы\n");
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.C)
                {
                    CharacterMenu();
                }
                else if (key.Key == ConsoleKey.F)
                {
                    Console.WriteLine("Не сделал;)");
                }
                else if (key.Key == ConsoleKey.S)
                {
                    SaveChanges();
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    SaveChanges();
                    Console.Clear();
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("" +
                        "\r\n██████╗░░█████╗░███╗░░██╗██╗████████╗  ██████╗░██╗███████╗" +
                        "\r\n██╔══██╗██╔══██╗████╗░██║╚█║╚══██╔══╝  ██╔══██╗██║██╔════╝" +
                        "\r\n██║░░██║██║░░██║██╔██╗██║░╚╝░░░██║░░░  ██║░░██║██║█████╗░░" +
                        "\r\n██║░░██║██║░░██║██║╚████║░░░░░░██║░░░  ██║░░██║██║██╔══╝░░" +
                        "\r\n██████╔╝╚█████╔╝██║░╚███║░░░░░░██║░░░  ██████╔╝██║███████╗" +
                        "\r\n╚═════╝░░╚════╝░╚═╝░░╚══╝░░░░░░╚═╝░░░  ╚═════╝░╚═╝╚══════╝");
                    Console.ReadKey();
                    break;
                }
            }
        }
        static void Main()
        {
            CharacterList = new List<DNDCharacter>();
            log = new Log();
            log.SetCharactersFromLog();
            StartMenu();
        }
    }
}
