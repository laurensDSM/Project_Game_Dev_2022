using Project_Game_Dev_2022.enemy_s;
using Project_Game_Dev_2022.money;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Game_Dev_2022
{
    public  class CollisionManager
    {
        public List<EnemyTeleport> EnemiesTeleport;
        public List<EnemyTrap> Traps;
        public List<EnemyBasic> EnemiesBasic;
        public List<Money> Money;





        public CollisionManager( List<EnemyTeleport> enemyTeleport, List<EnemyTrap> traps, List<EnemyBasic> enemiesBasic, List<Money> money)
        {
            EnemiesTeleport = enemyTeleport;
            Traps = traps;
            Money = money;
            EnemiesBasic = enemiesBasic;
        }

        internal bool HasCollidedWithTrap(Hero hero, Rectangle toekomstRectangle)
        {
            bool hasCollided = false;
            foreach (var i in Traps)
            {


                if (toekomstRectangle.Intersects(i.EnemyBox))
                {
                    hasCollided = true;
                    // Debug.WriteLine(" colide");


                }

            }

            return hasCollided;
        }
        internal bool HasCollidedWithEnemieTeleport(Hero hero, Rectangle toekomstRectangle)
        {
            bool hasCollided = false;
            foreach (var i in EnemiesTeleport)
            {
                if (toekomstRectangle.Intersects(i.EnemyBox))
                {
                    if ((toekomstRectangle.Bottom - i.EnemyBox.Top) < 7)
                    {
                        hasCollided = true;
                        i.IsAlive = false;
                    }
                }
                else
                {
                    hasCollided = false;
                }
            }

            return hasCollided;
        }
        internal bool HasCollidedWithEnemieBasic(Hero hero, Rectangle toekomstRectangle)
        {
            bool hasCollided = false;
            foreach (var i in EnemiesBasic)
            {
                if (toekomstRectangle.Intersects(i.EnemyBox))
                {

                    if ((toekomstRectangle.Bottom - i.EnemyBox.Top) < 7)
                    {
                        hasCollided = true;
                        i.IsAlive = false;
                    }
                }
                else
                {
                    hasCollided = false;
                }
            }

            return hasCollided;
        }

        internal bool HasCollidedWithMoney(Hero hero, Rectangle toekomstRectangle)
        {
            bool hasCollided = false;

            foreach (var i in Money)
            {
                if (toekomstRectangle.Intersects(i.MoneyBox))
                {

                    hasCollided = true;
                    i.IsUsed = true;
                    hero.money++;
                    //Debug.WriteLine("collision");

                }
                else
                {
                    hasCollided = false;
                }
            }


            return hasCollided;

        }


    }
}
