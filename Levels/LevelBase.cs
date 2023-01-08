using Microsoft.Xna.Framework;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_Dev_2022.Levels
{
    public abstract class LevelBase : GameScreen
    {
        protected LevelBase(Game game) : base(game)
        {
        }

        public abstract int Enemies { get; set; }
    }
}
