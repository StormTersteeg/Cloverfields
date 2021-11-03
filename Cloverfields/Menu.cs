using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloverfields
{
    static class Menu
    {
        public static void Redraw(World world)
        {
            Console.Clear();
            world.DrawMapBorder();
            world.DrawControlHints();
        }

        public static ConsoleColor GetConsoleColor(string color)
        {
            switch(color.ToLower().Replace(" ", ""))
            {
                case "red":
                    return ConsoleColor.Red;
                case "green":
                    return ConsoleColor.Green;
                case "blue":
                    return ConsoleColor.Blue;
                case "cyan":
                    return ConsoleColor.Cyan;
                case "gray":
                    return ConsoleColor.Gray;
                case "grey":
                    return ConsoleColor.Gray;
                case "white":
                    return ConsoleColor.White;
                case "black":
                    return ConsoleColor.Black;
                case "darkgray":
                    return ConsoleColor.DarkGray;
                case "darkgrey":
                    return ConsoleColor.DarkGray;
                case "yellow":
                    return ConsoleColor.Yellow;
                case "darkblue":
                    return ConsoleColor.DarkBlue;
                case "darkcyan":
                    return ConsoleColor.DarkCyan;
                case "darkgreen":
                    return ConsoleColor.DarkGreen;
                case "darkred":
                    return ConsoleColor.DarkRed;
                case "darkmagenta":
                    return ConsoleColor.DarkMagenta;
                case "darkyellow":
                    return ConsoleColor.DarkYellow;
                case "magenta":
                    return ConsoleColor.Magenta;
                default:
                    return ConsoleColor.White;
            }
        }

        public static void AddObject(World world)
        {
            Console.Clear();
            Console.WriteLine("\n\n   Create an Object");

            Console.WriteLine("\n\n   Object name:");
            Console.SetCursorPosition(3, 7);
            string name = Console.ReadLine();
            Console.WriteLine("\n\n   Object character:");
            Console.SetCursorPosition(3, 11);
            string character = Console.ReadLine();

            Console.WriteLine("\n\n   Color A:");
            Console.SetCursorPosition(3, 15);
            ConsoleColor colorA = GetConsoleColor(Console.ReadLine());

            Console.WriteLine("\n\n   Color B:");
            Console.SetCursorPosition(3, 19);
            ConsoleColor colorB = GetConsoleColor(Console.ReadLine());

            (int, int) pos = world.PlayerLocation;
            GameObject new_object = new GameObject(name, character, (pos.Item1, pos.Item2), colorA, colorB);
            world.Objects.Add(new_object);
            world.LastCreated = new_object;

            Redraw(world);
        }

        /*
        public static void Export(World world)
        {
            String export = "new List<GameObject>(){";
            foreach (GameObject obj in world.Objects)
            {
                export += $"new GameObject(\"{obj.Name}\", \"{obj.Character}\", ({obj.Position.Item1}, {obj.Position.Item2}), {obj.Foreground}, {obj.Background}),";
            }
            export += "};";

            Console.WriteLine(export);
            Console.ReadLine();
            Redraw(world);
        }
        */

        public static void Export(World world)
        {
            Console.Clear();
            foreach (GameObject obj in world.Objects)
            {
                Console.WriteLine(obj.Name);
                Console.WriteLine(obj.Character);
                Console.WriteLine(obj.Position.Item1);
                Console.WriteLine(obj.Position.Item2);
                Console.WriteLine(obj.Foreground);
                Console.WriteLine(obj.Background);
            }

            Console.ReadLine();
            Redraw(world);
        }

        public static void Import(World world)
        {
            Console.Clear();
            while(true)
            {
                string name = Console.ReadLine(); if (name.Equals("")) {break;}
                string character = Console.ReadLine();
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());
                ConsoleColor colorA = GetConsoleColor(Console.ReadLine());
                ConsoleColor colorB = GetConsoleColor(Console.ReadLine());
                world.Objects.Add(new GameObject(name, character, (x, y), colorA, colorB));
            }
            Redraw(world);
        }
    }
}
