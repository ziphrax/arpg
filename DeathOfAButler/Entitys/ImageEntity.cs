using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathOfAButler.Entitys
{
    public class ImageEntity : Entity {

        public Image image { get; set; }
        public ImageEntity(float x, float y, string path) : base(x, y) {

            image = new Image(path);
            AddGraphic(image);            
        }

    }
}
