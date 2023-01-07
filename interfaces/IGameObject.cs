using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Project_Game_Dev_2022.interfaces
{
    interface IGameObject
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
