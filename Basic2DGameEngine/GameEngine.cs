using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic2DGameEngine
{
    public abstract class GameEngine
    {
        private Vector2 ScreenSize = new Vector2(512, 512);
        private string Title = "New Game";
        private Canvas Window = null;
        private Thread GameLoopThread = null;

        public static List<BaseGameObject> AllObjects = new List<BaseGameObject>();

        public Color BackgroundColor = Color.Black;

        public Vector2 CameraPosition = new Vector2();
        public float CameraAngle = 0f;

        public GameEngine(Vector2 ScreenSize, string Title) {
            Log.Info("Game is starting");

            this.ScreenSize = ScreenSize;
            this.Title = Title;

            Window = new Canvas {
                Size = new Size((int)this.ScreenSize.X, (int)this.ScreenSize.Y),
                Text = this.Title
            };

            Window.Paint += Renderer;
            Window.FormClosed += Window_FormClosed;
            Window.KeyDown += Window_KeyDown;
            Window.KeyUp += Window_KeyUp;

            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            Application.Run(Window);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e) {
            GetKeyUp(e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) {
            GetKeyDown(e);
        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e) {
            GameLoopThread.Abort();
        }

        public static void RegisterGameObject(BaseGameObject gameObject) {
            AllObjects.Add(gameObject);
        }

        public static void UnregisterGameObject(BaseGameObject gameObject) {
            AllObjects.Remove(gameObject);
        }

        private void GameLoop() {
            OnLoad();

            while (GameLoopThread.IsAlive) {

                try {
                    OnDraw();

                    Window.BeginInvoke((MethodInvoker)delegate {
                        Window.Refresh();
                    });

                    OnUpdate();
                    Thread.Sleep(1);
                } catch {
                    Log.Error("Game has not been found ...");
                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.Clear(BackgroundColor);

            g.TranslateTransform(CameraPosition.X, CameraPosition.Y);
            g.RotateTransform(CameraAngle);

            foreach (BaseGameObject gameObject in AllObjects) {

                if (gameObject is Shape2D shape) {
                    g.FillRectangle(new SolidBrush(shape.Color), shape.Position.X, shape.Position.Y, shape.Scale.X, shape.Scale.Y);
                }

                if (gameObject is Sprite2D sprite) {
                    g.DrawImage(sprite.Sprite, sprite.Position.X, sprite.Position.Y, sprite.Scale.X, sprite.Scale.Y);
                }

                if (gameObject is Text2D text) {
                    g.DrawString(text.Text, text.Font, text.Brush, text.Position.X, text.Position.Y);
                }
            }
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnDraw();
        public abstract void GetKeyDown(KeyEventArgs e);
        public abstract void GetKeyUp(KeyEventArgs e);


    }
}
