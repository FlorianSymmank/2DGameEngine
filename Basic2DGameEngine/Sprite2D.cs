using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGameEngine
{
    public class Sprite2D : BasePhysicObject
    {
        public string Directory = "";
        public Bitmap Sprite;

        public Sprite2D(Vector2 Position, Vector2 Scale, string Tag, string Directory, Vector2 Velocity = null, float Mass = 0f) : base(Position, Scale, Tag, Velocity, Mass) {

            this.Directory = Directory;
            Sprite = Image.FromFile($"Assets/Sprites/{Directory}.jpg") as Bitmap;
        }
    }
}
