using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathOfAButler
{
    public class Hud : Entity
    {
        Text currentRoom;
        public Hud(int x = 0, int y = 0) : base(x, y) {
            currentRoom = new Text("", 16);
        }

        public override void Added()
        {
            base.Added();

            AddGraphic(currentRoom);
        }

        public override void Update()
        {
            base.Update();
            currentRoom.String = Program.currentScene;
        }
    }
}
