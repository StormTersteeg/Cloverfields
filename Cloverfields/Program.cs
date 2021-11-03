using System;
using System.Collections.Generic;

namespace Cloverfields
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WindowHeight = 72;
                Console.WindowWidth = 120;
            } catch (Exception) {}


            World world = new World(){Objects=new List<GameObject>(){}};
            Controller.Initialize(world);

            world.DrawMapBorder();
            world.DrawControlHints();

            while (true)
            {
                world.DrawObjects();
                ConsoleKeyInfo result = Console.ReadKey(true);
                world.UndrawObjects();
                Controller.Handle(result);
            }
        }
    }
}
