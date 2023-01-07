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
            if (toekomstRectangle.X > 800 || toekomstRectangle.X < 0 || toekomstRectangle.Y > 480 || toekomstRectangle.Y < 0)
            {
                hero.canJump = true;
                hero.isFalling = false;
            }
            //if (toekomstRectangle.X < 800 && toekomstRectangle.X > 0 && toekomstRectangle.Y < 480 && toekomstRectangle.Y > 0)

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
                    // Debug.WriteLine("hero.canJump = true;");
                    // Debug.WriteLine($"colide" + hero.counter);

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
            //UP
            if (direction.Y == -1)
            {


                if (hero.canJump && hero.counter <= 30)  //als canjump waar is dan is hij niet aan het vallen
                {
                    hero.isFalling = false;
                    //  Debug.WriteLine("jump");
                    hero.counter++;
                    //  Debug.WriteLine(hero.counter);

                }
                else  //als canjump nietwaar is dan is hij  aan het vallen
                {
                    hero.isFalling = true;
                }



                // als hij op geen blokje staat dan valt hij 

            }
            if (hero.isFalling)
            {
                direction.Y = 1;
            }
            return direction;
        }

    }
}