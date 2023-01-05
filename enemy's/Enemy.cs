using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game_Dev_2022.interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Game_Dev_2022
{
     public abstract class Enemy : IGameObject
    {


        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);


    }
}
