using Microsoft.Xna.Framework;
using MonoGame.Extended.Screens;

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
