using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Project_Game_Dev_2022
{
    public class MovementManager
    {
        public List<Rectangle> CollideablesLevel;

        public MovementManager(List<Rectangle> collideablesLevel)
        {
            this.CollideablesLevel = collideablesLevel;
        }

        internal bool HasCollided(Hero hero,  Rectangle toekomstRectangle)
        {
            if (toekomstRectangle.X > 800 || toekomstRectangle.X < 0 || toekomstRectangle.Y > 480 || toekomstRectangle.Y < 0)
            {
                hero.canJump = true;
                hero.isFalling = false;
            }
            if (toekomstRectangle.X < 800 && toekomstRectangle.X > 0 && toekomstRectangle.Y < 480 && toekomstRectangle.Y > 0)
            {

            }
            bool collided = false;
            foreach (var item in CollideablesLevel)
            {
                if (toekomstRectangle.Intersects(item))
                {
                    hero.isFalling = false;
                    hero.canJump = true;
                    collided = true;
                    break;
                }
                else
                {
                    hero.isFalling = true;
                }
            }
            return collided;

        }

        internal Vector2 Move(Hero hero, Vector2 direction)
        {
            if (direction.Y == -1)
            {


                if (hero.canJump)
                {
                    hero.isFalling = false;
                }
                else
                {
                    hero.isFalling = true;
                }

            }
            if (hero.isFalling)
            {
                direction.Y = 1;
            }
            return direction;
        }
    }
}