using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.Animation;
using Project_Game_Dev_2022.interfaces;

namespace Project_Game_Dev_2022
{
    public abstract class Enemy : IGameObject
    {

        protected Animatie animatie;

        public Enemy()
        {
            animatie = new Animatie();

        }
        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);


    }
}
