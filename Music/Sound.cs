using Microsoft.Xna.Framework.Audio;
using Project_Game_Dev_2022.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_Dev_2022.Music
{
    public class Sound : ISound
    {
        SoundEffect soundEffect;
        public Sound(SoundEffect soundEffect)
        {
            this.soundEffect = soundEffect;
        }
        public void PlaySound()
        {
            soundEffect.Play();
        }
    }
}
