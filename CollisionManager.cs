using Microsoft.Xna.Framework;
using Project_Game_Dev_2022.enemy_s;
using Project_Game_Dev_2022.money;
using Project_Game_Dev_2022.powerups;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project_Game_Dev_2022
{
    public class CollisionManager
    {
        public List<EnemyTeleport> EnemiesTeleport;
        public List<EnemyTrap> Traps;
        public List<EnemyBasic> EnemiesBasic;
        public List<Money> Money;
        public List<Immunity> Immunities;





        public CollisionManager(List<EnemyTeleport> enemyTeleport, List<EnemyTrap> traps, List<EnemyBasic> enemiesBasic, List<Money> money, List<Immunity> immunities)
        {
            EnemiesTeleport = enemyTeleport;
            Traps = traps;
            Money = money;
            EnemiesBasic = enemiesBasic;
            Immunities = immunities;
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
                    if (hero.immunity > 0)
                    {
                        hero.immunity--;
                    }


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

                    hero.money = hero.money + 50;
                    Debug.WriteLine(hero.money);

                    //Debug.WriteLine("collision");

                }
                else
                {
                    hasCollided = false;
                }
            }


            return hasCollided;

        }
        internal bool HasCollidedWithImmunity(Hero hero, Rectangle toekomstRectangle)
        {
            bool hasCollided = false;

            foreach (var i in Immunities)
            {
                if (toekomstRectangle.Intersects(i.ImmunityBox))
                {

                    hasCollided = true;
                    i.IsUsed = true;
                    hero.immunity = hero.immunity + 50;
                    //Waarde moet aangepast worden naar gelang je collison hebt met de trap
                    Debug.WriteLine($"Immunity" + " " + hero.immunity);

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
