using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloverfields
{
    public class GameObject
    {
        public string Name {get;set;}
        public string Character {get;set;}
        public (int, int) Position {get;set;} = (0, 0);
        public ConsoleColor Foreground {get;set;}
        public ConsoleColor Background {get;set;}

        public GameObject(string name, string character, (int, int) pos, ConsoleColor foreground, ConsoleColor background)
        {
            Name = name;
            Character = character;
            Position = pos;
            Foreground = foreground;
            Background = background;
        }

        public GameObject(string name, string character, (int, int) pos) : this(name, character, pos, ConsoleColor.White, ConsoleColor.Black) {}
    }
}
