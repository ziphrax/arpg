using Newtonsoft.Json.Linq;
using Otter;
using System;
using System.Collections.Generic;
using System.IO;
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

            int[][] tileMap = data?.TileMap?.ToObject<int[][]>();
            levelData.Graphics = ItterateOverTles<Graphic>(tileMap, GetTileImages);

            int[][] collisionMap = data?.CollisionMap?.ToObject<int[][]>();
            levelData.Colliders = ItterateOverTles<Collider>(collisionMap, GetTileColliders);

            levelData.PlayerSpawnX = data?.PlayerSpawnX;
            levelData.PlayerSpawnY = data?.PlayerSpawnY;

            return levelData;
        }


        private static List<T> ItterateOverTles<T>(int[][] data, ItteratorFunction<T> method) {    
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

        delegate T ItteratorFunction<T>(int value, int x, int y);

        private static BoxCollider GetTileColliders(int value, int x, int y) {
            BoxCollider currentTile = null;

            if (value != 0) { 
                currentTile = new BoxCollider(TileSizeX, TileSizeY, value);

                currentTile.X = x * TileSizeX;
                currentTile.Y = y * TileSizeY;

                currentTile.X += originX;
                currentTile.Y += originY;
            }

            return currentTile;
        }

        private static Image GetTileImages(int value,int x, int y) {
            var currentTile = new Image(Path.GetFullPath("Assets/Tiles/" + tiles[value]));
            currentTile.X = x * TileSizeX;
            currentTile.Y = y * TileSizeY;

            //Adjust for origin to center tiles
            currentTile.X += originX;
            currentTile.Y += originY;

            return currentTile;
        }


    }
}
