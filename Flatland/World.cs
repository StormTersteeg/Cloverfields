using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloverfields
{
    public class World
    {
        public List<GameObject> Objects {get;set;}
        public List<GameObject> CloseObjects {get;set;}
        public GameObject LastCreated {get;set;}

        public ((int, int),(int, int)) Scope {get;set;} = ((-25,-25),(25,25));

        public int MapDisplacement = 3;
        private ConsoleColor _mapBorder = ConsoleColor.Black;
        private string _mapBorderCharacter = "░";

        public int MapSize
        {
            get
            {
                return Scope.Item2.Item1 - Scope.Item1.Item1;
            }
        }

        public (int, int) PlayerLocation
        {
            get
            {
                return (Scope.Item1.Item1+(MapSize/2), Scope.Item1.Item2+(MapSize/2));
            }
        }

        public void RelativeScopeChange(int x, int y)
        {
            Scope = ((Scope.Item1.Item1 + x, Scope.Item1.Item2 + y),(Scope.Item2.Item1 + x, Scope.Item2.Item2 + y));
        }

        public List<GameObject> ObjectsIn((int, int) locationA, (int, int) locationB)
        {
            List<GameObject> temp_list = new List<GameObject>();

            foreach (GameObject obj in Objects)
            {
                if (obj.Position.Item1>=locationA.Item1 && obj.Position.Item1<=locationB.Item1 && obj.Position.Item2>=locationA.Item2 && obj.Position.Item2<=locationB.Item2)
                {
                    temp_list.Add(obj);
                }
            }
            return temp_list;
        }

        public void ResetCursor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0,0);
        }

        public void DrawMapBorder()
        {
            // Color map border
            Console.BackgroundColor = _mapBorder;
            for (int i = MapDisplacement; i < MapSize+2+MapDisplacement; i++)
            {
                Console.SetCursorPosition(MapDisplacement, i);
                Console.Write(_mapBorderCharacter);
                Console.SetCursorPosition(MapDisplacement+MapSize+2, i);
                Console.Write(_mapBorderCharacter);
                Console.SetCursorPosition(i, MapDisplacement);
                Console.Write(_mapBorderCharacter);
                Console.SetCursorPosition(i, MapDisplacement+MapSize+2);
                Console.Write(_mapBorderCharacter);
                System.Threading.Thread.Sleep(1);
            }
            // Missing corner piece
            Console.SetCursorPosition(MapDisplacement+MapSize+2, MapDisplacement+MapSize+2);
            Console.Write(_mapBorderCharacter);
        }

        public void DrawObjects() {
            CloseObjects = new List<GameObject>();
            GameObject StandingOn = null;

            foreach (GameObject obj in ObjectsIn(Scope.Item1, Scope.Item2))
            {
                Console.ForegroundColor = obj.Foreground;
                Console.BackgroundColor = obj.Background;

                Console.SetCursorPosition(obj.Position.Item1-Scope.Item1.Item1+MapDisplacement+1, obj.Position.Item2-Scope.Item1.Item2+MapDisplacement+1);
                Console.Write(obj.Character);

                // Collect Objects that are in interaction range
                (int, int) pos = PlayerLocation;
                if (obj.Position.Item1>=pos.Item1-1 && obj.Position.Item2>=pos.Item2-1 && obj.Position.Item1<=pos.Item1+1 && obj.Position.Item2<=pos.Item2+1)
                {
                    CloseObjects.Add(obj);
                }

                // Check if Player is standing on an Object
                if (obj.Position==pos)
                {
                    StandingOn = obj;
                }
            }

            // Player char
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = (StandingOn!=null) ? StandingOn.Background : ConsoleColor.Black;
            Console.SetCursorPosition(MapDisplacement+(MapSize/2)+1,MapDisplacement+(MapSize/2)+1);
            Console.Write("O");
            ResetCursor();

            // UI Elements
            DrawCoordinates(MapSize + 2);
            DrawInteractInfo();
            ResetCursor();
        }

        public void UndrawObjects()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;
            foreach (GameObject obj in ObjectsIn(Scope.Item1, Scope.Item2))
            {
                Console.SetCursorPosition(obj.Position.Item1-Scope.Item1.Item1+MapDisplacement+1, obj.Position.Item2-Scope.Item1.Item2+MapDisplacement+1);
                Console.Write(" ");
            }
            ResetCursor();
        }

        public void DrawText(string text, int height)
        {
            Console.SetCursorPosition(MapDisplacement+MapSize+5, MapDisplacement+height);
            Console.Write(text);
        }

        public void DrawText(string text, int height, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(MapDisplacement+MapSize+5, MapDisplacement+height);
            Console.Write(text);
            ResetCursor();
        }

        public void UndrawText(int height)
        {
            Console.SetCursorPosition(MapDisplacement+MapSize+5, MapDisplacement+height);
            Console.Write("                                                        ");
        }

        public void DrawCoordinates(int height)
        {
            (int, int) pos = PlayerLocation;
            UndrawText(height);
            DrawText($"X:{pos.Item1} Y:{pos.Item2}", height);
        }

        public void DrawInteractInfo()
        {
            for (int i = 0; i<9; i++)
            {
                UndrawText(i);
            }

            for (int i = 0; i<CloseObjects.Count; i++)
            {
                DrawText($"{CloseObjects[i].Character} {CloseObjects[i].Name}", i);
                DrawText($"{CloseObjects[i].Character}", i, CloseObjects[i].Foreground);
            }
        }

        public void DrawControlHints()
        {
            Console.SetCursorPosition(0, MapSize+MapDisplacement + 5);
            Console.WriteLine("                                              ");
            Console.WriteLine("                                              ");
            Console.WriteLine("                                              ");
            Console.WriteLine("                                              ");
            Console.WriteLine("                                              ");
            Console.WriteLine("                                              ");
            Console.WriteLine("                                              ");
            Console.WriteLine("                                              ");
            Console.WriteLine("                                              ");

            string last_created_placeholder = (LastCreated!=null) ? LastCreated.Name : "(Empty)";
            Console.SetCursorPosition(0, MapSize+MapDisplacement + 5);
            Console.WriteLine("   X: Create      [: Import");
            Console.WriteLine("\n   B: Delete      ]: Export");
            Console.WriteLine($"\n   C: Copy        V: Paste {last_created_placeholder}");
            Console.WriteLine("\n\n   ,: Place Marker");
            Console.WriteLine($"\n   .: Fill with {last_created_placeholder}");
            Console.WriteLine($"\n   /: Fill with Air");
        }

        public void DeleteAt((int, int) pos)
        {
            Objects.RemoveAll(obj => obj.Position.Equals(pos));
        }

        public void DeleteWithName(string name)
        {
            Objects.RemoveAll(obj => obj.Name.Equals(name));
        }

        public (int,int) GetObjectPositionByName(string name)
        {
            foreach (GameObject obj in Objects)
            {
                if (obj.Name.Equals(name))
                {
                    return obj.Position;
                }
            }
            return (1000000,1000000);
        }

        public GameObject GetObjectByPosition((int, int) pos)
        {
            foreach (GameObject obj in Objects)
            {
                if (obj.Position.Equals(pos)) {return obj;}
            }
            return null;
        }
    }
}
