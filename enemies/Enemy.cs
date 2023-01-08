using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.interfaces;

namespace Project_Game_Dev_2022
{
    public abstract class Enemie : IGameObject
    {
        protected Animation.Animation animation;
        public Enemie()
        {
            animation = new Animation.Animation();
        }
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
