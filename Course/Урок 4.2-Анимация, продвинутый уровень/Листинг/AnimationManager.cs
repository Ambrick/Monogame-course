using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lesson_4_2_Animation
{
    public class AnimationManager
    {
        private Animation _animation;

        private float _timer;

        public Vector2 Position { get; set; }

        //Конструктор класса
        public AnimationManager(Animation animation)
        {
            _animation = animation;
        }

        //Ф. по воспроизведению определенной анимации
        public void Play(Animation animation)
        {
            //Если предлагается переключение на ту же анимацию, то возврат
            if (_animation == animation)
                return;

            //Иначе переключение на новую анимацию
            //Обнуление текущего кадра, таймера
            _animation = animation;
            _animation.CurrentFrame = 0;
            _timer = 0;
        }

        //Ф. выставления одного кадра для "выключения" анимации
        public void Stop()
        {
            _animation.CurrentFrame = 0;
            _timer = 0;
        }

        //Ф. обновления анимации
        public void Update(GameTime gameTime)
        {
            //Обновление таймера
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Если прошло достаточно времени, то
            if (_timer > _animation.FrameSpeed)
            {
                //переключения кадра
                _timer = 0;
                _animation.CurrentFrame++;

                //если кадр последний, то переключение на нулевой кадр
                if (_animation.CurrentFrame >= _animation.FrameCount)
                    _animation.CurrentFrame = 0;
            }
        }

        //Ф. отрисовки спрайта
        public void Draw(SpriteBatch sprBatch, float Angle)
        {
            sprBatch.Draw( _animation.Texture, Position, _animation.DrawableRect, Color.White, Angle, _animation.FrameCenter, 1, SpriteEffects.None, 0);
        }
    }
}