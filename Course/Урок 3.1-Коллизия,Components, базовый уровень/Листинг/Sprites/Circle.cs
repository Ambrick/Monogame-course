using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lesson_3._1_Collision
{
    class Circle : GameComponent
    {
        private bool direction = false;

        public Circle(Game game, Texture2D texture, Vector2 position, string Object_type, int pix_per_step) : base(game, texture, position, Object_type)
        {
            this.texture = texture;
            this.position = position;
            this.Object_type = Object_type;
            this.pix_per_step = pix_per_step;

            Rectangle = new Rectangle(0,0, texture.Width, texture.Height);
        }

        public override void Update(GameTime gameTime)
        {
            if (direction)
            {
                if (position.Y - pix_per_step < 0)
                { 
                    direction = false;
                }
                else
                    position.Y -= pix_per_step;
                
            }
            else
            {
                if (position.Y + texture.Height + pix_per_step > Game1.ScreenHeight)
                {
                    direction = true;
                }
                else
                    position.Y += pix_per_step;
            }

            base.Update(gameTime);
        }
    }
}
