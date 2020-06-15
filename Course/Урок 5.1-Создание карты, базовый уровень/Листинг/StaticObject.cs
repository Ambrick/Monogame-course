using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lesson_5_Map_Base
{
    public class StaticObject : GameComponent
    {
        public StaticObject(Texture2D texture, Vector2 position, string Object_type) : base(texture, position, Object_type)
        {
            this.texture = texture;
            this.position = position;
            this.Object_type = Object_type;

            Rectangle = new Rectangle(0,0, texture.Width, texture.Height);
        }
    }
}
