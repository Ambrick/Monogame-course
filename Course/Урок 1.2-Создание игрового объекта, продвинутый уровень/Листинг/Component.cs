using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lesson_1._2
{
    //Класс компонента от "игрового компонента"
    public class Component : DrawableGameComponent
    {
        private Texture2D sprTexture;
        private Vector2 sprPosition;

        //Конструктор класса
        public Component(Game game, Texture2D newTexture, Vector2 newPosition) : base(game)
        {
            sprTexture = newTexture;
            sprPosition = newPosition;
        }

        //Отрисовка игрового компонента
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sprBatch = (SpriteBatch) Game.Services.GetService(typeof(SpriteBatch));

            sprBatch.Begin();
            sprBatch.Draw(sprTexture, sprPosition, Color.Red);
            sprBatch.End();
        }
    }
}
