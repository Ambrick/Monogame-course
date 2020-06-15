using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Lesson_4_Simple_Animation
{
    public class Sprite
    {
        public Vector2 Position { get; set; }

        private int pixels_per_step;

        private Vector2 Velocity;

        private float Angle = 0;
        
        private Animation animation;

        protected float Angl90 => (float) Math.Atan(90);

        private float _timer;

        //Конструктор класса
        public Sprite(Animation animation, Vector2 position)
        {
            Position = position;
            //Передаем в качестве параметра объект класс "Animation" передаем спрайт, количество "кадров" и скорость смены кадров
            this.animation = animation;

            pixels_per_step = 3;
            Velocity = Vector2.Zero;
        }

        //Ф. обновления игрвого объекта
        public void Update(GameTime gameTime)
        {
            //Считывание параметров клавиатуры
            var keyboardState = Keyboard.GetState();

            //Высчитвание угла в соответствии направлением
            //Формирование приращения к позиции
            if (keyboardState.IsKeyDown(Keys.W))
            {
                Angle = Angl90 * 3;
                Velocity.Y -= pixels_per_step;
            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                Angle = Angl90 * 1;
                Velocity.Y = pixels_per_step;
            }
            else if (keyboardState.IsKeyDown(Keys.A))
            {
                Angle = Angl90 * 2;
                Velocity.X -= pixels_per_step;
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                Angle = Angl90 * 0;
                Velocity.X = pixels_per_step;
            }

            //Если приращение равно 0
            if (Velocity != Vector2.Zero)
            {
                //Обновляем прошедшее время
                _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                //Если прошло достаточно времнеи для переключения анимации, то меняем кдр
                if (_timer > animation.FrameSpeed)
                {
                    _timer = 0;
                    animation.CurrentFrame++;

                    //Если достигли последнего кадра, то следующим выставляем нулевой
                    if (animation.CurrentFrame >= animation.FrameCount)
                        animation.CurrentFrame = 0;
                }
            }
            else
            {
                //Обнуляем анимацию
                animation.CurrentFrame = 0;
                _timer = 0;
            }

            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        //Ф. по отрисовке игрвого объекта
        public void Draw(SpriteBatch sprBatch)
        {
            sprBatch.Draw(animation.Texture, Position, animation.DrawableRect, Color.White, Angle, animation.FrameCenter, 1, SpriteEffects.None, 0);
        }
    }
}
