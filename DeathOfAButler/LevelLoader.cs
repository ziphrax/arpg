using DeathOfAButler.Entitys;
using Newtonsoft.Json.Linq;
using Otter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathOfAButler
{
    public static class LevelLoader
    {
        static string[] tiles;
        static int TileSizeX;
        static int TileSizeY;
        static int originX;
        static int originY;
        public static LevelData Load(string path) {
            LevelData levelData = new LevelData();
                        
            dynamic data = JObject.Parse(File.ReadAllText(Path.GetFullPath(path)));

            levelData.TileSizeX = TileSizeX = (int)data?.TileSizeX;
            levelData.TileSizeY = TileSizeY = (int)data?.TileSizeX;

            TileSizeY = (int)data?.TileSizeY;
            tiles = data?.Tiles?.ToObject<string[]>();

            //values to center map by
            levelData.OriginX = originX = Game.Instance.HalfWidth - ((data?.TileMap?[0]?.Count * TileSizeX) / 2);
            levelData.OriginY = originY = Game.Instance.HalfHeight - ((data?.TileMap?.Count * TileSizeY) / 2);

            string[][] tileMap = data?.TileMap?.ToObject<string[][]>();
            levelData.Graphics = ItterateOverTles<Graphic>(tileMap, GetTileImages);

            string[][] collisionMap = data?.CollisionMap?.ToObject<string[][]>();
            levelData.Colliders = ItterateOverTles<Collider>(collisionMap, GetTileWalls);

            string[][] doorsMap = data?.DoorsMap?.ToObject<string[][]>();
            levelData.Doors = ItterateOverTles<Collider>(doorsMap, GetTileDoors);

            levelData.PlayerSpawnX = data?.PlayerSpawnX;
            levelData.PlayerSpawnY = data?.PlayerSpawnY;

            return levelData;
        }


        private static List<T> ItterateOverTles<T>(string[][] data, ItteratorFunction<T> method) {    
            var items = new List<T>();           

            for (var y = 0; y < data.Length; y++)
            {
                for (var x = 0; x < data[y].Length; x++)
                {
                    object tmp = method(value: data[y][x], x: x, y: y);
                    if (tmp != null) {
                        items.Add((T)tmp);
                    }                    
                }
            }

            return items;
        }

        delegate T ItteratorFunction<T>(string value, int x, int y);
        

        private static DoorCollider GetTileDoors(string value, int x, int y)
        {
            DoorCollider currentTile = null;
            int valueInt;
            if (int.TryParse(value,out valueInt))
            {
                //shouldnt add anything here
            }
            else {
                currentTile = new DoorCollider(TileSizeX, TileSizeY, Tags.Doors);
                currentTile.Room = value;

                currentTile.X = x * TileSizeX;
                currentTile.Y = y * TileSizeY;

                currentTile.X += originX;
                currentTile.Y += originY;
            }
                     
            return currentTile;
        }

        private static BoxCollider GetTileWalls(string value, int x, int y) {
            BoxCollider currentTile = null;
            var valueInt = int.Parse( value);
            if (valueInt != 0) { 
                currentTile = new BoxCollider(TileSizeX, TileSizeY, Tags.Walls);

                currentTile.X = x * TileSizeX;
                currentTile.Y = y * TileSizeY;

                currentTile.X += originX;
                currentTile.Y += originY;
            }

            return currentTile;
        }

        private static Image GetTileImages(string value,int x, int y) {            
            var valueInt = int.Parse(value);
            Image currentTile = null;
            if (int.TryParse(value, out valueInt))
            {                
                currentTile = new Image(Path.GetFullPath("Assets/Tiles/" + tiles[valueInt]));
                currentTile.X = x * TileSizeX;
                currentTile.Y = y * TileSizeY;

                //Adjust for origin to center tiles
                currentTile.X += originX;
                currentTile.Y += originY;
            }           

            return currentTile;
        }


    }
}
