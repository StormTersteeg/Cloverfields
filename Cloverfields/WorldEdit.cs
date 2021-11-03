using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloverfields
{
    public static class WorldEdit
    {
        public static void Fill(World world)
        {
            (int, int) markerLocation = world.GetObjectPositionByName("#WE1");
            if (world.LastCreated!=null && markerLocation!=(1000000,1000000)) {
                (int, int) playerLocation = world.PlayerLocation;

                if (markerLocation.Item1<playerLocation.Item1)
                {
                    if (markerLocation.Item2<playerLocation.Item2)
                    {
                        for (int x = markerLocation.Item1; x < playerLocation.Item1+1; x++) {
                            for (int y = markerLocation.Item2; y < playerLocation.Item2+1; y++) {
                                world.Objects.Add(new GameObject(
                                    world.LastCreated.Name,
                                    world.LastCreated.Character,
                                    (x, y),
                                    world.LastCreated.Foreground,
                                    world.LastCreated.Background
                                ));
                            }
                        }
                    }
                    else
                    {
                        for (int x = markerLocation.Item1; x < playerLocation.Item1+1; x++) {
                            for (int y = markerLocation.Item2; y > playerLocation.Item2-1; y--) {
                                world.Objects.Add(new GameObject(
                                    world.LastCreated.Name,
                                    world.LastCreated.Character,
                                    (x, y),
                                    world.LastCreated.Foreground,
                                    world.LastCreated.Background
                                ));
                            }
                        }
                    }
                } else
                {
                    if (markerLocation.Item2<playerLocation.Item2)
                    {
                        for (int x = markerLocation.Item1; x >= playerLocation.Item1; x--) {
                            for (int y = markerLocation.Item2; y < playerLocation.Item2+1; y++) {
                                world.Objects.Add(new GameObject(
                                    world.LastCreated.Name,
                                    world.LastCreated.Character,
                                    (x, y),
                                    world.LastCreated.Foreground,
                                    world.LastCreated.Background
                                ));
                            }
                        }
                    }
                    else
                    {
                        for (int x = markerLocation.Item1; x > playerLocation.Item1-1; x--) {
                            for (int y = markerLocation.Item2; y > playerLocation.Item2-1; y--) {
                                world.Objects.Add(new GameObject(
                                    world.LastCreated.Name,
                                    world.LastCreated.Character,
                                    (x, y),
                                    world.LastCreated.Foreground,
                                    world.LastCreated.Background
                                ));
                            }
                        }
                    }
                }

                world.DeleteWithName("#WE1");
            }
        }

        public static void RemoveArea(World world)
        {
            (int, int) markerLocation = world.GetObjectPositionByName("#WE1");
            if (world.LastCreated!=null && markerLocation!=(1000000,1000000)) {
                (int, int) playerLocation = world.PlayerLocation;

                if (markerLocation.Item1<playerLocation.Item1)
                {
                    if (markerLocation.Item2<playerLocation.Item2)
                    {
                        for (int x = markerLocation.Item1; x < playerLocation.Item1+1; x++) {
                            for (int y = markerLocation.Item2; y < playerLocation.Item2+1; y++) {
                                world.Objects.RemoveAll(obj => obj.Position==(x,y));
                            }
                        }
                    }
                    else
                    {
                        for (int x = markerLocation.Item1; x < playerLocation.Item1+1; x++) {
                            for (int y = markerLocation.Item2; y > playerLocation.Item2-1; y--) {
                                world.Objects.RemoveAll(obj => obj.Position==(x,y));
                            }
                        }
                    }
                } else
                {
                    if (markerLocation.Item2<playerLocation.Item2)
                    {
                        for (int x = markerLocation.Item1; x >= playerLocation.Item1; x--) {
                            for (int y = markerLocation.Item2; y < playerLocation.Item2+1; y++) {
                                world.Objects.RemoveAll(obj => obj.Position==(x,y));
                            }
                        }
                    }
                    else
                    {
                        for (int x = markerLocation.Item1; x > playerLocation.Item1-1; x--) {
                            for (int y = markerLocation.Item2; y > playerLocation.Item2-1; y--) {
                                world.Objects.RemoveAll(obj => obj.Position==(x,y));
                            }
                        }
                    }
                }

                world.DeleteWithName("#WE1");
            }
        }
    }
}
