using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lesson_1._2
{
    //Класс спарайта
    public class Sprite
    {
        public Texture2D Texture { get; }
        public Vector2 Position { get; }

        //Конструктор класса, принимающий текстуру и позицию игрового объекта
        public Sprite(Texture2D newSpTexture, Vector2 newSpPosition)
        {
            Texture = newSpTexture;
            Position = newSpPosition;
        }
    }
}
