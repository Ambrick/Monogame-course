using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Lesson_5_2_Map
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private static int cell_size = 64;

        public static int ScreenWidth { get { return cell_size * 7; } }
        public static int ScreenHeight { get { return cell_size * 7; } }

        public static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        public Level lvl;
        public static Circle Master;

        public static List<StaticObject> StaticObjects = new List<StaticObject>();

        private int[,] Level1 = {
           { 1, 1, 1, 1, 1, 1, 1 },
           { 1, 2, 0, 1, 0, 0, 1 },
           { 1, 0, 0, 1, 0, 0, 1 },
           { 1, 0, 0, 0, 0, 0, 1 },
           { 1, 0, 0, 1, 0, 0, 1 },
           { 1, 0, 0, 1, 0, 3, 1 },
           { 1, 1, 1, 1, 1, 1, 1 },
           };


        private int[,] Level2 = {
           { 1, 1, 1, 1, 1, 1, 1 },
           { 1, 0, 1, 0, 0, 0, 1 },
           { 1, 0, 0, 0, 1, 0, 1 },
           { 1, 1, 0, 0, 1, 0, 1 },
           { 1, 1, 0, 1, 1, 0, 1 },
           { 1, 2, 0, 1, 3, 0, 1 },
           { 1, 1, 1, 1, 1, 1, 1 },
           };

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.ApplyChanges();

            

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            textures.Add("circle", Content.Load<Texture2D>("circle"));
            textures.Add("ball", Content.Load<Texture2D>("ball"));
            textures.Add("square", Content.Load<Texture2D>("1"));
            lvl = new Level(1, Level1);
        }

        protected override void Update(GameTime gameTime)
        {
            //Обновление управляемого объекта
            Master.Update(gameTime);
            //Если при обновлении уровня  обнаружена коллизия красного кргуга с синим, то
            if (lvl.Update(gameTime))
            {
                //Обнуляем красный круг
                Master = null;
                StaticObjects.Clear();
                //Если уровень был первый, то загружаем второй
                if (lvl.game_lvl==1)
                {
                    lvl.LoadLevel(Level2, 2);
                }
                //Если уровень был второй, то загружаем первый
                else
                {
                    lvl.LoadLevel(Level1, 1);
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            spriteBatch.Begin();
            Master.Draw(spriteBatch);
            foreach (GameComponent spr in StaticObjects)
            {
                spr.Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}
