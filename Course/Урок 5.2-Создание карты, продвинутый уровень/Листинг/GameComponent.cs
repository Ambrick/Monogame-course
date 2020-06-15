using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lesson_5_2_Map
{
    public class GameComponent
    {
        protected int pix_per_step;
        protected Vector2 Velocity;
        protected Vector2 position;
        protected Texture2D texture;

        public GameComponent( Texture2D texture, Vector2 position, string Object_type) { }

        public Vector2 Velo { get { return Velocity; } set => Velocity = value; }
        public string Object_type { get; set; }
        public bool IsDead { get; set; } = false;
        public Vector2 Position { get { return position; } set => position = value; }
        public Rectangle Rectangle { get; protected set; }
        public Rectangle Properties => new Rectangle((int)Position.X - Rectangle.Width / 2, (int)Position.Y - Rectangle.Height / 2, Rectangle.Width, Rectangle.Height);
        
        public virtual void Draw(SpriteBatch sprBatch)
        {
            sprBatch.Draw(texture, Position, Rectangle, Color.White, 0, new Vector2(texture.Width, texture.Height) / 2, 1, SpriteEffects.None, 1);
        }
    }
}
