using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lesson_2_Keyboard_writing
{
    class Input
    {
        private double click__timer = 0;

        private string str { get; set; } = string.Empty;

        private SpriteFont font;

        //Конструктор класса
        public Input(SpriteFont font)
        {
            //Присваивание шрифта для отрисовки
            this.font = font;
        }

        //Ф. по обновлению состояния ввода
        public void Update(GameTime gameTime)
        {
            //Обновление таймера для создания задержки клика
            click__timer -= click__timer > 0 ? gameTime.ElapsedGameTime.TotalSeconds : 0;

            //Получение нажатых клавиш
            Keys [] keys_array = Keyboard.GetState().GetPressedKeys();
            //Если есть нажатые клавиши и таймер клика меньше нуля, то
            if (keys_array.Length != 0 && click__timer <= 0)
            {
                //Объявляется 1 символ из набор нажатых клавиш
                Keys first_key = keys_array[0];

                //Если клавиша "возврат", то происходит удаление последнего символа
                if (first_key == Keys.Back)
                    str = str.Remove(str.Length - 1);

                //Если строка меньше 15 символов, то добавить символ к строке после перевода
                else if (!(str.Length > 15))
                    str += GetLetter(first_key);

                //Выставление таймера
                click__timer = 0.15;
            }
        }
        
        //Ф. по отрисовке строки
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, str, new Vector2(0, 50), Color.Black);
        }

        //Ф. по "переводу" ангийских символов к русским
        private string GetLetter(Keys key)
        {
            switch (key)
            {
                case Keys.Q:
                    return "Й";
                case Keys.W:
                    return "Ц";
                case Keys.E:
                    return "У";
                case Keys.R:
                    return "К";
                case Keys.T:
                    return "Е";
                case Keys.Y:
                    return "Н";
                case Keys.U:
                    return "Г";
                case Keys.I:
                    return "Ш";
                case Keys.O:
                    return "Щ";
                case Keys.P:
                    return "З";
                case Keys.OemOpenBrackets:
                    return "Х";
                case Keys.OemCloseBrackets:
                    return "Ъ";
                case Keys.A:
                    return "Ф";
                case Keys.S:
                    return "Ы";
                case Keys.D:
                    return "В";
                case Keys.F:
                    return "А";
                case Keys.G:
                    return "П";
                case Keys.H:
                    return "Р";
                case Keys.J:
                    return "О";
                case Keys.K:
                    return "Л";
                case Keys.L:
                    return "Д";
                case Keys.Z:
                    return "Я";
                case Keys.X:
                    return "Ч";
                case Keys.C:
                    return "С";
                case Keys.V:
                    return "М";
                case Keys.B:
                    return "И";
                case Keys.N:
                    return "Т";
                case Keys.M:
                    return "Ь";
                case Keys.Space:
                    return " ";
                case Keys.OemQuotes:
                    return "Э";
                case Keys.OemQuestion:
                    return ".";
                case Keys.OemComma:
                    return "Б";
                case Keys.OemPeriod:
                    return "Ю";
                default:
                    return "*";
            }
        }
    }
}
