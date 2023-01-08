using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_Dev_2022.money
{
    public class Wallet
    {
        public int Value { get; set; }
        private Wallet()
        {
        }
        private static Wallet _instance = new Wallet();
        public static Wallet Instance
        {
            get { return _instance; }
        }




    }
}
