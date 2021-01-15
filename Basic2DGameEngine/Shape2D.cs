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
        public Color Color { get; set; } = Color.Black;
        public Shape2D(Vector2 Position, Vector2 Scale, string Tag, Color Color, Vector2 Velocity = null, float Mass = 0f) : base(Position, Scale, Tag, Velocity, Mass) {
            this.Color = Color;
        }
    }
}
