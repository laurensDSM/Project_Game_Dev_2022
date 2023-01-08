using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_Dev_2022.money
{
    public class Powerups
    {
        public int Value { get; set; }
        private Powerups()
        {
        }
        private static Powerups _instance = new Powerups();
        public static Powerups Instance
        {
            get { return _instance; }
        }
    }
}
