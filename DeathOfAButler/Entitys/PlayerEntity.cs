using DeathOfAButler.Scenes;
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
        BoxCollider boxCollider;
        int moveSpeed = 3;
        public PlayerEntity(int x,int y) : base(x:x, y:y) {
            playerSprite = Image.CreateRectangle(20, Color.Cyan);
            boxCollider = new BoxCollider(20, 20, Tags.Player);

            AddCollider(boxCollider);

            AddGraphic(playerSprite);

            AddComponents(
                new TopDownMovement(Input.Instance, moveSpeed),
                new CanMoveThroughDoors(),
                new CanRestartFromHallway(Input.Instance)
            );
        }

        public override void Update() {
            base.Update();
            //Check for collision with walls (1);
            if (boxCollider.Overlap(X, Y, Tags.Walls)) {

            }
        }
      
        public override void Render()
        {
            base.Render();
            boxCollider.Render();
        }

    }

    class CanRestartFromHallway : Component
    {
        Input i;
        public CanRestartFromHallway(Input input)
        {
            i = input;
        }
        public override void Update()
        {
            base.Update();
            if (i.KeyDown(Key.R)) Game.Instance.SwitchScene(new MainGameScene("EntranceHallWay"));
        }
    }

    class CanMoveThroughDoors : Component
    {
        public override void Update()
        {
                base.Update();
            if (Entity.Collider.Overlap(Entity.X, Entity.Y, Tags.Doors)) {
                //teleport
                Game.Instance.SwitchScene(new MainGameScene("Room1"));
            }
        }
    }

    class TopDownMovement : Component {
        Input i;
        int _moveSpeed;
        public TopDownMovement(Input input, int speed ) : base() {
            i = input;
            _moveSpeed = speed;
        }

        public override void Update()  {
            base.Update();           

            if (i.KeyDown(Key.W) && !Entity.Collider.Overlap(Entity.X, Entity.Y - _moveSpeed, 1)) Entity.Y -= _moveSpeed;          
            if (i.KeyDown(Key.S) && !Entity.Collider.Overlap(Entity.X, Entity.Y + _moveSpeed, 1)) Entity.Y += _moveSpeed;         
            if (i.KeyDown(Key.A) && !Entity.Collider.Overlap(Entity.X - _moveSpeed, Entity.Y, 1)) Entity.X -= _moveSpeed;
            if (i.KeyDown(Key.D) && !Entity.Collider.Overlap(Entity.X + _moveSpeed, Entity.Y, 1)) Entity.X += _moveSpeed;           
            
        }

    }
}
