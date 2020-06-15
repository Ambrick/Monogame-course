using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_4_2_Animation
{
    public class Sprite
    {
        private Vector2 position;

        public  Vector2 Position
        {
            get { return position; }
            set
            {
                position = value;
                AnimationManager.Position = position;
            }
        }

        private int pixels_per_step;

        private Vector2 Velocity;

        private float Angle = 0;

        protected float Angl90 => (float)Math.Atan(90);

        protected Dictionary<string, Animation> Animations;

        protected AnimationManager AnimationManager;

        //Конструктор калсса в который передаем хэш массив анимаций и позицию
        public Sprite(Dictionary<string, Animation> animations, Vector2 position)
        {
            //Передаем список полученный анимаций в анимации
            Animations = animations;
            //Выставляем первую анимацию
            AnimationManager = new AnimationManager(Animations.Values.First());

            Position = position;
            pixels_per_step = 3;
            Velocity = Vector2.Zero;
        }

        //Ф. по обновлению игрового объекта
        public void Update(GameTime gameTime)
        {
            //Считывание состояния клавиатуры
            var keyboardState = Keyboard.GetState();

            //Формирование угла поворота и приращения к позиции
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

            //Если был нажат пробел, то "переключение на анимацию удара
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                AnimationManager.Play(Animations["Hit"]);
                Velocity = Vector2.Zero;
            }
            //Если приращение не нулевое, то переключение на анимацию движения
            else if (Velocity != Vector2.Zero)
                AnimationManager.Play(Animations["Move"]);
            //Иначе выставление в качестве анимации нулевого кадра
            else
                AnimationManager.Stop();

            Position += Velocity;
            Velocity = Vector2.Zero;

            AnimationManager.Update(gameTime);
        }

        //Ф. по отрисовке игрового объекта
        public void Draw(SpriteBatch sprBatch)
        {
            AnimationManager.Draw(sprBatch, Angle);
        }
    }
}
