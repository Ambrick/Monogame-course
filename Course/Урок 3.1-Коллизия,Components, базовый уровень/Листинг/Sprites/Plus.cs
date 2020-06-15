using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lesson_3._1_Collision
{
    public class Plus : GameComponent
    {
        public Plus(Game game, Texture2D texture, Vector2 position, string Object_type) : base(game, texture, position, Object_type)
        {
            this.texture = texture;
            this.position = position;
            this.Object_type = Object_type;

            Rectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }
    }
}
