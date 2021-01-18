using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGameEngine
{
    public class Text2D : BaseGameObject
    {
        public string Text { get; set; }
        public Font Font { get; set; } = new Font("Tahoma", 15);
        public Brush Brush { get; set; } = new SolidBrush(System.Drawing.Color.Red);

        public Text2D(Vector2 Position, string Tag, string Text, Font Font = null, Brush Brush = null) : base(Position, null, Tag) {
            this.Text = Text;
            this.Font = Font ?? new Font("Tahoma", 15);
   
            this.Brush = Brush ?? new SolidBrush(System.Drawing.Color.Red);
        }
    }
}
