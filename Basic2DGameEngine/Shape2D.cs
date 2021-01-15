using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGameEngine
{
    public class Shape2D : BaseGameObject
    {
        public Color Color = Color.Black;
        public Shape2D(Vector2 Position, Vector2 Scale, string Tag, Color Color) : base(Position, Scale, Tag) {
            this.Color = Color;
        }
    }
}
