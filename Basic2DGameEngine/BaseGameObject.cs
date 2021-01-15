﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGameEngine
{
    public class BaseGameObject
    {
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public Vector2 Velocity = new Vector2();
        public string Tag = "";
        public float Mass = 0;

        public BaseGameObject(Vector2 Position, Vector2 Scale, string Tag) {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;

            Log.Info($"[GameObject] {Tag} - GameObject registerd");
            GameEngine.RegisterGameObject(this);
        }

        public BaseGameObject(Vector2 Position, Vector2 Scale, Vector2 Velocity, string Tag, float Mass) : this(Position, Scale, Tag) {
            this.Velocity = Velocity;
            this.Mass = Mass;
        }

        public void DestroySelf() {
            Log.Info($"[GameObject] {Tag} - GameObject destroyed");
            GameEngine.UnregisterGameObject(this);
        }

        public void ApplyForce(Vector2 force, float dt) {

            if (Mass == 0)
                return;

            if (IsColliding("player")) {
                Velocity = new Vector2();
                return;
            }

            Vector2 acceleration = new Vector2(force.X / Mass, force.Y / Mass);

            Velocity.X += acceleration.X * dt;
            Velocity.Y += acceleration.Y * dt;

            Position.X += Velocity.X * dt;
            Position.Y += Velocity.Y * dt;

            Velocity.X = Math.Min(Velocity.X, 1);
            Velocity.Y = Math.Min(Velocity.Y, 1);
        }

        public bool IsColliding(string tag) {

            foreach (BaseGameObject gameObject in GameEngine.AllObjects.Where(x => x.Tag == tag && x != this)) {
                if (Position.X < gameObject.Position.X + gameObject.Scale.X &&
                Position.X + Scale.X > gameObject.Position.X &&
                Position.Y < gameObject.Position.Y + gameObject.Scale.Y &&
                Position.Y + Scale.Y > gameObject.Position.Y)
                    return true;
            }

            return false;
        }
    }
}