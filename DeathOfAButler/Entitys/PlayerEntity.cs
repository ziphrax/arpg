using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathOfAButler.Entitys
{
    public class PlayerEntity : Entity
    {
        Image playerSprite;
        public PlayerEntity(int x,int y) : base(x, y) {
            playerSprite = Image.CreateRectangle(32, Color.Cyan);
        }
    }
}
