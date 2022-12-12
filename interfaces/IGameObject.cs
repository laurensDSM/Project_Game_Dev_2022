using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Project_Game_Dev_2022.interfaces
{
    interface IGameObject
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
