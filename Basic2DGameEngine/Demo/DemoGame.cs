using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Basic2DGameEngine.Demo
{
    public class DemoGame : GameEngine
    {
        static Vector2 Resolution = new Vector2(615, 515);

        bool SpacePressed = false;

        Stopwatch stopwatch = new Stopwatch();
        int FrameCounter = 0;

        Sprite2D player;
        Sprite2D player2;
        Sprite2D player3;
        Shape2D shape;
        Text2D text;

        Vector2 Gravity = new Vector2(0, 0.005f);
        Vector2 Jump = new Vector2(0, -0.1f);

        Vector2 previousPos = new Vector2();
        float distanceTraveled = 0;

        public DemoGame() : base(Resolution, "Demo game") { }

        public override void OnLoad() {
            BackgroundColor = Color.Blue;
            shape = new Shape2D(new Vector2(10, 10), new Vector2(10, 10), "Test", Color.Yellow);
            player = new Sprite2D(new Vector2(10, 150), new Vector2(20, 20), "player", "pepega");
            player2 = new Sprite2D(new Vector2(50, 20), new Vector2(20, 20), "player", "pepega");
            player3 = new Sprite2D(new Vector2(80, 150), new Vector2(20, 20), "player", "pepega", new Vector2(0.1f, -0.15f), 35);
            text = new Text2D(new Vector2(80, 150), "text", "Hier sollte Text stehen");

            System.Timers.Timer Timer = new System.Timers.Timer();
            Timer.Elapsed += Timer_Tick;
            Timer.Interval = 1000;
            Timer.Enabled = true;

            stopwatch.Start();
        }

        private void Timer_Tick(object sender, ElapsedEventArgs e) {
            Log.Info($"FPS: {FrameCounter}, MS per Frame: {1000d / FrameCounter}ms");
            FrameCounter = 0;
        }

        public override void OnDraw() {
            FrameCounter++;
        }

        public override void OnUpdate() {

            // time between updates
            float dt = stopwatch.ElapsedMilliseconds;

            foreach (BasePhysicObject pyhsicObject in AllObjects.OfType<BasePhysicObject>()) {
                pyhsicObject.ApplyForce(Gravity, dt);
            }

            distanceTraveled += previousPos.X - player3.Position.X;
            previousPos = new Vector2(player3.Position.X, 0);

            if (SpacePressed) {
                player3.ApplyForce(Jump, dt);
            }

            CameraPosition.X = -player3.Position.X + Resolution.X / 2;


            text.Position.X = player3.Position.X - 15;
            text.Position.Y = 15;
            text.Text = distanceTraveled.ToString();


            stopwatch.Restart();
        }

        public override void GetKeyDown(KeyEventArgs e) {

            SpacePressed = e.KeyCode == Keys.Space;
        }

        public override void GetKeyUp(KeyEventArgs e) {
            SpacePressed = !(e.KeyCode == Keys.Space);
        }
    }
}
