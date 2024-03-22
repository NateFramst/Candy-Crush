using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Candy_Crush
{
    internal class Candy
    {
        public int type;
        public int location;
        public Boolean candyVisible;

        public  SolidBrush typeBrush;

        public static float Cwidth = 15;
        public static float Cheight = 15;

        public Candy(int _type, int _location, bool _candyVisible)
        {
            type = _type;
            location = _location;
            candyVisible = _candyVisible;

            if (type == 0)
            {
                typeBrush = new SolidBrush(Color.Red);
            }
            else if (type == 1)
            {
                typeBrush = new SolidBrush(Color.Blue);
            }
            else if (type == 2)
            {
                typeBrush = new SolidBrush(Color.Orange);
            }
            else
            {
                typeBrush = new SolidBrush(Color.Green);
            }
        }
    }
}
