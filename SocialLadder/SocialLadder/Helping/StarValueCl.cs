using System;
using System.Collections.Generic;
using System.Text;

namespace SocialLadder
{
    class StarValueCl
    {
        // функция возвращающая смайликовое представление рейтинга
        public static string StarValue(double st)
        {
            if (st < 15) return "   ★   ";
            else if (st < 25) return "  ☆☆  ";
            else if (st < 35) return " ✩✩✩ ";
            else if (st < 45) return " ⭐⭐⭐⭐ ";
            else if (st < 55) return "⭐⭐⭐⭐⭐";
            else if (st < 65) return "⭐⭐⭐⭐⭐⭐";
            else if (st < 75) return "   🤩   ";
            else if (st < 85) return "✨🤩✨";
            else if (st < 95) return " ☄🤩☄ ";
            else return "   🌟   ";
        }

        // функция позвращающая hex цвета
        public static string Hex(int st)
        {
            switch (st)
            {
                case 0: return "ff6666";
                case 1: return "ff6e4a";
                case 2: return "f4c800";
                case 3: return "d1e231";
                case 4: return "75c1ff";
                case 5: return "6495ed";
                case 6: return "7366bd";
                case 7: return "9966cc";
                case 8: return "9966dc";
                case 9: return "9966ec";
                default: return "9966ec";
            }
        }
    }
}
