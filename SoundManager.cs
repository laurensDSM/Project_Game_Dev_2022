using Project_Game_Dev_2022.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_Dev_2022
{
    public  class SoundManager
    {
        public SoundManager(ISound soundType)
        {
            soundType.PlaySound();
        }
    }
}
