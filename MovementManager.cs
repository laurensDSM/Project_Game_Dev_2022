using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Project_Game_Dev_2022
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

            bool collided = false;
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

                if (hero.canJump && hero.counter <= 30)  //als canjump waar is dan is hij niet aan het vallen
                {
                    hero.isFalling = false;
                    hero.counter++;

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