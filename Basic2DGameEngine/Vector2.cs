using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGameEngine
{
    public class Vector2
    {
        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;

        public Vector2() {

        }

        public Vector2(float X, float Y) {
            this.X = X;
            this.Y = Y;
        }

        public override string ToString() {

            return $"X:{X} Y:{Y}";
        }
    }
}
