using Microsoft.Xna.Framework;
using Project_Game_Dev_2022.enemies;
using Project_Game_Dev_2022.Levels;
using Project_Game_Dev_2022.money;
using Project_Game_Dev_2022.powerups;
using Project_Game_Dev_2022.HeroMap;
using System.Collections.Generic;


namespace Project_Game_Dev_2022.Managers
{
    public class CollisionManager
    {
        public List<EnemyTeleport> EnemiesTeleport;
        public List<EnemyTrap> Traps;
        public List<EnemyBasic> EnemiesBasic;
        public List<Money> Money;
        public List<Immunity> Immunities;
        private LevelBase level;
        public CollisionManager(List<EnemyTeleport> enemyTeleport, List<EnemyTrap> traps, List<EnemyBasic> enemiesBasic, List<Money> money, List<Immunity> immunities, LevelBase level)
        {
            EnemiesTeleport = enemyTeleport;
            Traps = traps;
            Money = money;
            EnemiesBasic = enemiesBasic;
            Immunities = immunities;
            this.level = level;
        }
        internal bool HasCollidedWithTrap(Hero hero, Rectangle toekomstRectangle)
        {
            bool hasCollided = false;
            foreach (var i in Traps)
            {
                if (toekomstRectangle.Intersects(i.EnemyHitBox))
                {
                    hasCollided = true;
                    i.IsAlive = false;
                    if (hero.immunity == 0)
                    {
                        hero.levels--;
                    }
                    if (hero.immunity > 0)
                    {
                        hero.immunity--;
                    }
                    if (Powerups.Instance.Value >= 1)
                    {
                        Powerups.Instance.Value = Powerups.Instance.Value - 1;
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
                    if (toekomstRectangle.Bottom - i.EnemyBox.Top < 7)
                    {
                        hasCollided = true;
                        i.IsAlive = false;
                        level.Enemies--;
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
                    if (toekomstRectangle.Bottom - i.EnemyBox.Top < 7)
                    {
                        hasCollided = true;
                        i.IsAlive = false;
                        level.Enemies--;
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
                    hero.money = hero.money + 1;
                    Wallet.Instance.Value = Wallet.Instance.Value + 5;
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
                    hero.immunity++;
                    Powerups.Instance.Value = Powerups.Instance.Value + 1;
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
