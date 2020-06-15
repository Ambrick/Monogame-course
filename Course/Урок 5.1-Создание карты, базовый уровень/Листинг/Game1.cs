using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Lesson_5_Map_Base
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Размер ячейки
        private static int cell_size = 64;

        //Выставление параметров для размеров карты
        public static int ScreenWidth { get { return cell_size * 7; } }
        public static int ScreenHeight { get { return cell_size * 7; } }

        //Объявление матрицы для карты
        public static int[,] Level1 = {
           { 1, 1, 1, 1, 1, 1, 1 },
           { 1, 2, 0, 1, 0, 0, 1 },
           { 1, 0, 0, 1, 0, 0, 1 },
           { 1, 0, 0, 0, 0, 0, 1 },
           { 1, 0, 0, 1, 0, 0, 1 },
           { 1, 0, 0, 1, 0, 0, 1 },
           { 1, 1, 1, 1, 1, 1, 1 },
           };

        //Констурктор класса
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        //Список статичных объектов
        public static List <StaticObject> StaticObjects = new List<StaticObject>();
        //Класс круг, который используется как объект для манипуляции
        private Circle Master;

        //Инициализация класса, изменение разрешения экрана
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.ApplyChanges();

            base.Initialize();
        }

        //Заполнение карты объектами, согласно матрице
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Проходим по всей матрице
            for (int i = 0; i < Level1.GetLongLength(0); i++)
            {
                for (int j = 0; j < Level1.GetLongLength(1); j++)
                {
                    Vector2 Position = new Vector2(i * cell_size + cell_size/2, j * cell_size + cell_size / 2);
                    //Если значения матрицы равно 1, то добавляем "квадрат"
                    if (Level1[i,j] == 1)
                    {
                        StaticObjects.Add(new StaticObject(Content.Load<Texture2D>("square"), Position, "square"));
                    }
                    //Если значения матрицы равно 1, то добавляем "квадрат"
                    else if (Level1[i, j] == 2)
                    {
                        Master = new Circle(Content.Load<Texture2D>("circle"), Position, "square", 2, this);
                    }
                }
            }
        }

        //Обновление игры
        protected override void Update(GameTime gameTime)
        {
            Master.Update(gameTime);
        }

        //Отрисовка игровых компонентов
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            spriteBatch.Begin();
            Master.Draw(spriteBatch);
            //Перебор всех статичных объектов для отрисовки
            foreach (GameComponent spr in StaticObjects)
            {
                spr.Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}
