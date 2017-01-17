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

            TileSizeX = (int)data?.TileSizeX;
            TileSizeY = (int)data?.TileSizeY;
            tiles = data?.Tiles?.ToObject<string[]>();
            //values to center map by
            originX = Game.Instance.HalfWidth - ((data?.TileMap?[0]?.Count * TileSizeX) / 2);
            originY = Game.Instance.HalfHeight - ((data?.TileMap?.Count * TileSizeY) / 2);

            int[][] tileMap = data?.TileMap?.ToObject<int[][]>();

            levelData.Graphics = ItterateOverTles<Graphic>(tileMap, GetTileImages);
            return levelData;
        }


        private static List<T> ItterateOverTles<T>(int[][] data, ItteratorFunction<T> method) {    
            var items = new List<T>();           

            for (var y = 0; y < data.Length; y++)
            {
                for (var x = 0; x < data[y].Length; x++)
                {
                    items.Add( method( value: data[y][x], x:x , y:y ) );
                }
            }

            return items;
        }

        delegate T ItteratorFunction<T>(int value, int x, int y);

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
