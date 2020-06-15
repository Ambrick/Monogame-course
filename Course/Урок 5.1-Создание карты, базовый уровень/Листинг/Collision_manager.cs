namespace Lesson_5_Map_Base
{

    public static class Collision_manager
    {
        public static bool CheckCollision(GameComponent spr1, GameComponent spr2)
        {
            return  (spr1.Velo.X > 0 && IsTouchingLeft(spr1, spr2)) || (spr1.Velo.X < 0 && IsTouchingRight (spr1, spr2)) ||
                    (spr1.Velo.Y > 0 && IsTouchingTop (spr1, spr2)) || (spr1.Velo.Y < 0 && IsTouchingBottom(spr1, spr2));
        }

        public static bool Collision_X(GameComponent spr1, GameComponent spr2)
        {
            return (spr1.Velo.X > 0 && IsTouchingLeft(spr1, spr2)) || (spr1.Velo.X < 0 && IsTouchingRight(spr1, spr2));
        }

        public static bool Collision_Y(GameComponent spr1, GameComponent spr2)
        {
            return (spr1.Velo.Y > 0 && IsTouchingTop(spr1, spr2)) || (spr1.Velo.Y < 0 && IsTouchingBottom(spr1, spr2));
        }

        private static bool IsTouchingLeft(GameComponent spr1, GameComponent spr2)
        {
            return (spr1.Properties.Right + spr1.Velo.X > spr2.Properties.Left) &&
              (spr1.Properties.Left < spr2.Properties.Left) &&
              (spr1.Properties.Bottom > spr2.Properties.Top) &&
              (spr1.Properties.Top < spr2.Properties.Bottom);
        }

        private static bool IsTouchingRight(GameComponent spr1, GameComponent spr2)
        {
            return (spr1.Properties.Left + spr1.Velo.X < spr2.Properties.Right) &&
             ( spr1.Properties.Right > spr2.Properties.Right) &&
             ( spr1.Properties.Bottom > spr2.Properties.Top) &&
             ( spr1.Properties.Top < spr2.Properties.Bottom);
        }

        private static bool IsTouchingTop(GameComponent spr1, GameComponent spr2)
        {
            return (spr1.Properties.Bottom + spr1.Velo.Y > spr2.Properties.Top) &&
              (spr1.Properties.Top < spr2.Properties.Top )&&
              (spr1.Properties.Right > spr2.Properties.Left) &&
              (spr1.Properties.Left < spr2.Properties.Right);
        }

        private static bool IsTouchingBottom(GameComponent spr1, GameComponent spr2)
        {
            return (spr1.Properties.Top + spr1.Velo.Y < spr2.Properties.Bottom) &&
             ( spr1.Properties.Bottom > spr2.Properties.Bottom) &&
             ( spr1.Properties.Right > spr2.Properties.Left) &&
             ( spr1.Properties.Left < spr2.Properties.Right);
        }
    }
}