using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathOfAButler
{
    public class LevelData
    {
        public int TileSizeX { get; set; }
        public int TileSizeY { get;  set;}

        public int OriginX { get; set; }
        public int OriginY { get; set; }

        public List<Graphic> Graphics { get; set; }
        public List<Collider> Colliders { get; set; }
        public List<Collider> Doors { get; set; }
        public int PlayerSpawnX { get; set; }
        public int PlayerSpawnY { get; set; }

        
    }
}
