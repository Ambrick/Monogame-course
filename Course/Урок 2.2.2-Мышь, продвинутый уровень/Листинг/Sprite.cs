using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Lesson_2_Rotation_Camera
{
    public class Sprite
    {
        public Texture2D Texture { get; }
        public Vector2 Position { get; set; }
        
        private int pixels_per_step;
        private Vector2 Velocity;

        protected float angle;
        public float Angle { get { return angle; } set => angle = value; }

        public Rectangle Rectangle { get; protected set; }
        public Rectangle Properties => new Rectangle((int)Position.X - Rectangle.Width / 2, (int)Position.Y - Rectangle.Height / 2, Rectangle.Width, Rectangle.Height);

        //Констурктор класса
        public Sprite(Texture2D newSpTexture, Vector2 newSpPosition)
        {
            Texture = newSpTexture;
            Position = newSpPosition;
            Rectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);

            pixels_per_step = 2;
            Velocity = Vector2.Zero;
        }

        //Ф. по обновлению объекта
        public void Update(GameTime gameTime)
        {
            //Считывание состояния мыши
            var mouseSt = Mouse.GetState();
            //Получение угла поворта спрайта к координатам мыши
            Angle = (float) Math.Atan2(mouseSt.Y - Game1.ScreenHeight / 2, mouseSt.X - Game1.ScreenWidth / 2);

            //Получение состояния мыши
            var keyboardState = Keyboard.GetState();

            //Приращение шага
            if (keyboardState.IsKeyDown(Keys.W))
                Velocity.Y -= pixels_per_step;
            else if (keyboardState.IsKeyDown(Keys.S))
                Velocity.Y = pixels_per_step;

            if (keyboardState.IsKeyDown(Keys.A))
                Velocity.X -= pixels_per_step;
            else if (keyboardState.IsKeyDown(Keys.D))
                Velocity.X = pixels_per_step;
            
            Position += Velocity;
            Velocity = Vector2.Zero;
        }


        //Ф. по отрисовке спрайта
        public void Draw(SpriteBatch sprBatch)
        {
            sprBatch.Draw(Texture, Position, Rectangle, Color.White, Angle, new Vector2(Texture.Width, Texture.Height) / 2, 1, SpriteEffects.None, 1);
        }
    }
}
