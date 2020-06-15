using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_2_Map
{
    public class Level
    {
        //Размер ячейки
        private const int cell_size = 64;
        
        //Номер уровня
        public int game_lvl;

        //Конструктор уровня (номер уровня, матрица карты)
        public Level(int lvl, int[,] level_matrix)
        {
            //Загрузка уровня
            LoadLevel(level_matrix, lvl);
        }

        //Ф. обновления уровня
        public bool Update(GameTime gameTime)
        {
            //Перебираем все статичные объекты
            foreach (GameComponent spr in Game1.StaticObjects)
                //Если этот объект "синий круг" и есть коллизия, то возвращаем true
                if (spr.Object_type == "ball" && spr.Properties.Intersects(Game1.Master.Properties))
                    return true;
            
            return false;
        }

        //Ф. для загрузки уровня
        public void LoadLevel(int[,] LVL, int lvl)
        {
            //Присваивание номера уровня
            game_lvl = lvl;

            //Перебор загруженной матрицы
            for (int i = 0; i< LVL.GetLongLength(0); i++)
            {
                for (int j = 0; j< LVL.GetLongLength(1); j++)
                {
                    //Высчитывание позиции
                    Vector2 Position = new Vector2(i * cell_size + cell_size / 2, j * cell_size + cell_size / 2);
                    //Если  значение в ячейке матрицы равно 1
                    if (LVL[i, j] == 1)
                    {
                        //Добавляем квадрат в расчитанной позиции
                        Game1.StaticObjects.Add(new StaticObject(Game1.textures["square"], Position, "square"));
                    }
                    //Если  значение в ячейке матрицы равно 2
                    else if (LVL[i, j] == 2)
                    {
                        //Добавляем красный круг в расчитанной позиции
                        Game1.Master = new Circle(Game1.textures["circle"], Position, "circle", 2);
                    }
                    //Если  значение в ячейке матрицы равно 3
                    else if (LVL[i, j] == 3)
                    {
                        //Добавляем синий круг в расчитанной позиции
                        Game1.StaticObjects.Add(new StaticObject(Game1.textures["ball"], Position, "ball"));
                    }
                }
            }
        }
    }
}
