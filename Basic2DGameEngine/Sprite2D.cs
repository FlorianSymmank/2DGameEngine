using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGameEngine
{
    public class Sprite2D : BaseGameObject
    {
        public string Directory = "";
        public Bitmap Sprite = null;

        public Sprite2D(Vector2 Position, Vector2 Scale, string Tag, string Directory) : base(Position, Scale, Tag) {

            this.Directory = Directory;
            Sprite = Image.FromFile($"Assets/Sprites/{Directory}.jpg") as Bitmap;
        }

        public Sprite2D(Vector2 Position, Vector2 Scale, Vector2 Velocity, string Tag, string Directory, float Mass) : base(Position, Scale, Velocity, Tag, Mass) {

            this.Velocity = Velocity;
            this.Directory = Directory;
            Sprite = Image.FromFile($"Assets/Sprites/{Directory}.jpg") as Bitmap;
            this.Mass = Mass;
        }
    }
}
