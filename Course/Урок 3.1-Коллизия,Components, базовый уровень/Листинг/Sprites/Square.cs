using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lesson_3._1_Collision
{
    public class Square : GameComponent
    {
        private Game1 game1;

        //Конструктор класса
        public Square(Game game, Texture2D texture, Vector2 position, string Object_type, int pix_per_step, Game1 game1) : base(game, texture, position, Object_type)
        {
            //Присваивание характеристик игрового объекта
            this.texture = texture;
            this.position = position;
            this.Object_type = Object_type;
            this.pix_per_step = pix_per_step;
            this.game1 = game1;

            Rectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }
        
        //Ф. по обновлению объекта
        public override void Update(GameTime gameTime)
        {
            //Если объект вышел за границы экрана, то выставляется флаг "мертвый"
            if (position.X + pix_per_step > Game1.ScreenWidth)
                IsDead = true;

            //Приращение шага к позиции
            position.X += pix_per_step;

            //Перебор всей коллекции игровых объектов
            foreach (GameComponent spr1 in game1.Components.ToArray())
            {
                //Если объект - это круг и границы данного спрайта накладываются на область круга
                if (spr1.Object_type == "circle" && Properties.Intersects(spr1.Properties))
                {
                    game1.Kill();
                    spr1.IsDead = true;
                }
            }

            base.Update(gameTime);
        }
    }
}
