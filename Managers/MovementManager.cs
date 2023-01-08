using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Project_Game_Dev_2022.HeroMap;

namespace Project_Game_Dev_2022.Managers
{
    public class MovementManager
    {
        public List<Rectangle> CollideablesLevel;
        public MovementManager(List<Rectangle> collideablesLevel)
        {
            CollideablesLevel = collideablesLevel;
        }
        internal bool HasCollided(Hero hero, Rectangle toekomstRectangle)
        {
            foreach (var item in CollideablesLevel)
            {
                if (toekomstRectangle.Intersects(item))
                {
                    if (toekomstRectangle.Left < item.Right && toekomstRectangle.Bottom - 5 > item.Top)
                    {
                        hero.isFalling = true;
                        hero.canJump = false;
                    }
                    else
                    {
                        hero.canJump = true;
                        hero.isFalling = false;
                        hero.counter = 0;
                    }
                    return true;
                }
                else
                {
                    hero.isFalling = true;
                }
            }
            return false;
        }
        internal Vector2 Move(Hero hero, Vector2 direction)
        {
            if (direction.Y == -1)
            {
                if (hero.canJump && hero.counter <= 30)
                {
                    hero.isFalling = false;
                    hero.counter++;
                }
                else
                {
                    hero.isFalling = true;
                }
            }
            if (direction.X == +1 || direction.X == 0)
            {
                hero.left = true;
            }
            else
            {
                hero.left = false;
            }
            if (hero.isFalling)
            {
                direction.Y = 1;
            }
            return direction;
        }
    }
}