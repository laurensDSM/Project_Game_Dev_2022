﻿using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_Dev_2022.Input
{
    class KeyboardReader : IInputReader
    {
     
            public Vector2 ReadInput()
            {
                KeyboardState state = Keyboard.GetState();
                Vector2 direction = Vector2.Zero;
                if (state.IsKeyDown(Keys.Left))
                {
                    direction.X -= 1;
                }
                if (state.IsKeyDown(Keys.Right))
                {
                    direction.X += 1;
                }
                if (state.IsKeyDown(Keys.Up))
                {
                    direction.Y -= 1;
                }
                if (state.IsKeyDown(Keys.Down))
                {
                    direction.Y += 1;
                }
            return direction;
            }

        
    }
}
