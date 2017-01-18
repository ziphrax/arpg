using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathOfAButler.Entitys
{
    public class DoorCollider : BoxCollider
    {
        public String Room { get; set; }
        public DoorCollider(int x, int y,params int[] tags) : base(x,y,tags){}

        public DoorCollider(int width, int height, Enum tag, params Enum[] tags) : base(width, height, tag, tags)
        {
        }
    }
}
