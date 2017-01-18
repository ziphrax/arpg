using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathOfAButler.Entitys
{
    public class CollisionEntity : Entity
    {
        public bool DoRender { get; set; }
        public CollisionEntity(int x, int y, bool render) : base(x: x, y: y) {
            DoRender = render;
        }

        public void AddColliders(List<Collider> colliders)
        {
            foreach (var col in colliders) AddCollider(col);
        }

        public override void Render()
        {
            base.Render();

            // Render the Hitbox for debug purposes.
            if (DoRender) {
                foreach (Collider col in Colliders) col.Render();
            } 
        }
    }
}
