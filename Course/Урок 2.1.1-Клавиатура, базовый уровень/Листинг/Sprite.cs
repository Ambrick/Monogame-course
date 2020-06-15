using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lesson_2_Keyboard_base
{
    public class Sprite
    {
        public Texture2D Texture { get; }
        public Vector2 Position { get; set; }

        private Rectangle rect;
        private int pixels_per_step;
        private Vector2 Velocity;

        //Конструктор класса "Sprite"
        public Sprite(Texture2D newSpTexture, Vector2 newSpPosition)
        {
            //Постановление характеристик спрайта
            Texture = newSpTexture;
            Position = newSpPosition;
            rect = new Rectangle (0,0,Texture.Width,Texture.Height);
            //Выставление величины прирощения шага
            pixels_per_step = 10;
        }

        //Ф. по "обновлению" класса "Sprite"
        public void Update(GameTime gameTime)
        {
            //Считывания состояния клавиатуры
            var keyboardState = Keyboard.GetState();

            //Формирование шага
            if (keyboardState.IsKeyDown(Keys.W))
                Velocity.Y -= pixels_per_step;
            else if (keyboardState.IsKeyDown(Keys.S))
                Velocity.Y = pixels_per_step;

            if (keyboardState.IsKeyDown(Keys.A))
                Velocity.X -= pixels_per_step;
            else if (keyboardState.IsKeyDown(Keys.D))
                Velocity.X = pixels_per_step;

            //Проверка на выход объекта из-за границ, если 1, то обнуление шага
            if (Position.X + Velocity.X + rect.Width > Game1.ScreenWidth || Position.X + Velocity.X < 0)
                Velocity.X = 0;
            if (Position.Y + Velocity.Y + rect.Height > Game1.ScreenHeight || Position.Y + Velocity.Y < 0)
                Velocity.Y = 0;

            //Прирощение к позиции шага
            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        //Ф. по отрисовке спрайта
        public void Draw(SpriteBatch sprBatch)
        {
            sprBatch.Draw(Texture, Position, Color.White);
        }
    }
}
