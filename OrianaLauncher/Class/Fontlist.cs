using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrianaLauncher.Class
{
    public class Fontlist
    {
        public float sizeS;
        public float sizeM;
        public float sizeL;
        public float sizeXL;
        public int temp;

        public Fontlist(int height)
        {
            sizeS = 16 - (int)((1620 - height) / 90);
            sizeM = 20 - (int)((1620 - height) / 90);
            sizeL = 22 - (int)((1620 - height) / 90);
            sizeXL = 40 - (int)((1620 - height) / 45);
            temp = -30 + (int)((1620 - height) / 22);
        }
    }
}
