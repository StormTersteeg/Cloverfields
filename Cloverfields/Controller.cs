using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloverfields
{
    public static class Controller
    {
        public static World World {get;set;}

        public static void Initialize(World world)
        {
            World = world;
        }

        public static void Handle(ConsoleKeyInfo input)
        {
            (int, int) playerLocation = World.PlayerLocation;

            switch(input.KeyChar)
            {
                case 'a':
                    World.RelativeScopeChange(-1, 0);
                    break;
                case 'd':
                    World.RelativeScopeChange(1, 0);
                    break;
                case 'w':
                    World.RelativeScopeChange(0, -1);
                    break;
                case 's':
                    World.RelativeScopeChange(0, 1);
                    break;
                case 'x':
                    Menu.AddObject(World);
                    break;
                case 'c':
                    World.LastCreated = World.GetObjectByPosition(playerLocation);
                    World.DrawControlHints();
                    break;
                case 'v':
                    if (World.LastCreated!=null) {
                        World.Objects.Add(new GameObject(
                            World.LastCreated.Name,
                            World.LastCreated.Character,
                            playerLocation,
                            World.LastCreated.Foreground,
                            World.LastCreated.Background
                        ));
                    }
                    break;
                case 'b':
                    World.DeleteAt(World.PlayerLocation);
                    break;
                case ',':
                    World.DeleteWithName("#WE1");
                    World.Objects.Add(new GameObject(
                        "#WE1",
                        "!",
                        playerLocation,
                        ConsoleColor.Red,
                        ConsoleColor.White
                    ));
                    break;
                case '.':
                    WorldEdit.Fill(World);
                    break;
                case '/':
                    WorldEdit.RemoveArea(World);
                    break;
                case '[':
                    Menu.Import(World);
                    break;
                case ']':
                    Menu.Export(World);
                    break;
            }
        }
    }
}
