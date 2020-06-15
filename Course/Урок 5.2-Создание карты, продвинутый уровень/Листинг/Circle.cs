using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lesson_5_2_Map
{ 
    public class Circle : GameComponent
    {

        public Circle(Texture2D texture, Vector2 position, string Object_type, int pix_per_step) : base( texture, position, Object_type)
        {
            this.texture = texture;
            this.position = position;
            this.Object_type = Object_type;
            this.pix_per_step = pix_per_step;

            Rectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }
        
        public virtual void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.W))
                Velocity.Y -= pix_per_step;
            else if (keyboardState.IsKeyDown(Keys.S))
                Velocity.Y = pix_per_step;

            if (keyboardState.IsKeyDown(Keys.A))
                Velocity.X -= pix_per_step;
            else if (keyboardState.IsKeyDown(Keys.D))
                Velocity.X = pix_per_step;

            Check();

            position += Velocity;
            Velocity = Vector2.Zero;
        }

        public virtual void Check()
        {
            foreach (GameComponent spr in Game1.StaticObjects)
            {
                if (spr.Object_type == "square")
                {
                    Velocity.X = Collision_manager.Collision_X(this, spr) ? 0 : Velocity.X;
                    Velocity.Y = Collision_manager.Collision_Y(this, spr) ? 0 : Velocity.Y;
                }
            }
        }
    }
}
