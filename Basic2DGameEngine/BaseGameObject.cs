using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGameEngine
{
    public class BaseGameObject
    {
        public Vector2 Position;
        public Vector2 Scale;
        public string Tag;


        public BaseGameObject(Vector2 Position, Vector2 Scale, string Tag, Vector2 Velocity = null, float Mass = 0f) {

            this.Position = Position ?? new Vector2();
            this.Scale = Scale ?? new Vector2();
            this.Tag = Tag;

            Log.Info($"[GameObject] {Tag} - GameObject registerd");
            GameEngine.RegisterGameObject(this);
        }


        public void DestroySelf() {
            Log.Info($"[GameObject] {Tag} - GameObject destroyed");
            GameEngine.UnregisterGameObject(this);
        }        
    }
}
