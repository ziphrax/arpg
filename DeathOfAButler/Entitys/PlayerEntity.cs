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
        Axis axisMovement;
        int moveSpeed = 10;
        public PlayerEntity(int x,int y) : base(x:x, y:y) {
            axisMovement = Axis.CreateWASD();
            playerSprite = Image.CreateRectangle(32, Color.Cyan);

            AddGraphic(playerSprite);

            AddComponents(
                new TopDownMovement(axisMovement, moveSpeed)
            );
        }
    }

    class TopDownMovement : Component {
        Axis _axis;
        int _moveSpeed;
        public TopDownMovement(Axis axis, int speed ) : base() {
            _axis = axis;
            _moveSpeed = speed;
        }

        public override void Update()  {
            base.Update();

            Entity.AddPosition(_axis, _moveSpeed);

        }

    }
}
