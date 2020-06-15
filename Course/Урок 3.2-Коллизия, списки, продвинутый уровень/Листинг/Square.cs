using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lesson_3._2_Collision
{ 
    public class Square : GameComponent
    {
        //Конструктор класса принимающий параметры игрового объекта
        public Square(Texture2D texture, Vector2 position, string Object_type, int pix_per_step, Game1 game1) : base( texture, position, Object_type)
        {
            //Присваивание параметров объекта
            this.texture = texture;
            this.position = position;
            this.Object_type = Object_type;
            this.pix_per_step = pix_per_step;

            Rectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }
        
        //Ф. обновления игрового объекта
        public virtual void Update(GameTime gameTime)
        {
            //Считывание состояния клавиатуры
            var keyboardState = Keyboard.GetState();

            //Формирование приращения к позиции
            if (keyboardState.IsKeyDown(Keys.A))
                Velocity.X -= pix_per_step;
            else if (keyboardState.IsKeyDown(Keys.D))
                Velocity.X = pix_per_step;
            if (keyboardState.IsKeyDown(Keys.W))
                Velocity.Y -= pix_per_step;
            else if (keyboardState.IsKeyDown(Keys.S))
                Velocity.Y = pix_per_step;

            //Если приращение не равно нулю
            if (Velocity != Vector2.Zero)
            {
                //Перебираем все игровые компоненты в списке кругов
                foreach (GameComponent spr in Game1.circles)
                {
                    //Проверка наличия коллизии по осям X и Y
                    //Передаем в менеджер коллизий, приведенные к родительскому классу, игровые объекты
                    //Если после приращения шага объект сталкивается с объектом "круг", то обнуляем шаг по соответствующей оси
                    if (Collision_manager.Collision_X(this, spr))
                        Velocity.X = 0;
                    if (Collision_manager.Collision_Y(this, spr))
                        Velocity.Y = 0;
                }
            }

            //Изменения позиции игрового объекта
            position += Velocity;
            Velocity = Vector2.Zero;
        }
    }
}
