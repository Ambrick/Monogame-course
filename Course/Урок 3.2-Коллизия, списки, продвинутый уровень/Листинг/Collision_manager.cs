namespace Lesson_3._2_Collision
{
    //Статический класс для проверки коллизий
    public static class Collision_manager
    {
        //Ф. на проверку наличие коллизии
        public static bool CheckCollision(GameComponent spr1, GameComponent spr2)
        {
            //Если есть коллизия по оси Х или по оси Н, то возвращает true
            return  Collision_X(spr1,spr2) || Collision_Y(spr1, spr2);
        }

        //Ф. на проверку наличие коллизии по оси X
        public static bool Collision_X(GameComponent spr1, GameComponent spr2)
        {
            return (spr1.Velo.X > 0 && IsTouchingLeft(spr1, spr2)) || (spr1.Velo.X < 0 && IsTouchingRight(spr1, spr2));
        }

        //Ф. на проверку наличие коллизии по оси E
        public static bool Collision_Y(GameComponent spr1, GameComponent spr2)
        {
            return (spr1.Velo.Y > 0 && IsTouchingTop(spr1, spr2)) || (spr1.Velo.Y < 0 && IsTouchingBottom(spr1, spr2));
        }

        //Ф. проверка на проверку позиции объекта слева относительного другого объекта
        private static bool IsTouchingLeft(GameComponent spr1, GameComponent spr2)
        {
            return (spr1.Properties.Right + spr1.Velo.X > spr2.Properties.Left) &&
              (spr1.Properties.Left < spr2.Properties.Left) &&
              (spr1.Properties.Bottom > spr2.Properties.Top) &&
              (spr1.Properties.Top < spr2.Properties.Bottom);
        }

        //Ф. проверка на проверку позиции объекта справа относительного другого объекта
        private static bool IsTouchingRight(GameComponent spr1, GameComponent spr2)
        {
            return (spr1.Properties.Left + spr1.Velo.X < spr2.Properties.Right) &&
             ( spr1.Properties.Right > spr2.Properties.Right) &&
             ( spr1.Properties.Bottom > spr2.Properties.Top) &&
             ( spr1.Properties.Top < spr2.Properties.Bottom);
        }

        //Ф. проверка на проверку позиции объекта сверху относительного другого объекта
        private static bool IsTouchingTop(GameComponent spr1, GameComponent spr2)
        {
            return (spr1.Properties.Bottom + spr1.Velo.Y > spr2.Properties.Top) &&
              (spr1.Properties.Top < spr2.Properties.Top )&&
              (spr1.Properties.Right > spr2.Properties.Left) &&
              (spr1.Properties.Left < spr2.Properties.Right);
        }

        //Ф. проверка на проверку позиции объекта снизу относительного другого объекта
        private static bool IsTouchingBottom(GameComponent spr1, GameComponent spr2)
        {
            return (spr1.Properties.Top + spr1.Velo.Y < spr2.Properties.Bottom) &&
             ( spr1.Properties.Bottom > spr2.Properties.Bottom) &&
             ( spr1.Properties.Right > spr2.Properties.Left) &&
             ( spr1.Properties.Left < spr2.Properties.Right);
        }
    }
}