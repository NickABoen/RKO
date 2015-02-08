using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RkoOuttaNowhere.Gameplay.Projectiles;
using RkoOuttaNowhere.Gameplay.Units;
using RkoOuttaNowhere.Images;
using RkoOuttaNowhere.Input;
using RkoOuttaNowhere.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RkoOuttaNowhere.Gameplay
{
    public class Player : GameObject
    {

        private List<Projectile> _projectiles;
        private int damageModifier, delay = 0;
        private float speedModifier;
        private Upgrades.ammunition ammo = Upgrades.ammunition.Fire;

        private Image _stand;


        public Player() : base()
        {
            _position = Vector2.Zero;
            _stand = new Image();
            _projectiles = new List<Projectile>();
            damageModifier = 0;
            speedModifier = 20;

        }

        public override void LoadContent() 
        {
            base.LoadContent();
            _position = new Vector2(825, 75);

            _image.Path = "Gameplay/gun_placement_dynamic";
            _image.Position = _position;
            _image.Scale = 2 * Vector2.One;
            _image.LoadContent();
            _stand.Path = "Gameplay/gun_placement_static";
            _stand.Position = _position + new Vector2(-12, 20);
            _stand.LoadContent();
        }

        public override void UnloadContent() 
        {
            base.UnloadContent();

            foreach(Projectile l in _projectiles)
            {
                l.UnloadContent();
            }
            _stand.UnloadContent();
        }

        public override void Update(GameTime gametime) 
        {
            base.Update(gametime);

            if (InputManager.Instance.LeftMouseDown() || InputManager.Instance.LeftMouseClick())
            {
                if (delay%20 == 0)
                {
                    _projectiles.Add(ProjectileFactory.Shoot(_position, damageModifier, ammo));
                    delay = 0;
                }
                delay++;
            }

            foreach(Projectile l in _projectiles)
            {
                l.Update(gametime);
            }
            _image.Position = _position;
            _image.Update(gametime);

            _stand.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch) 
        {
            _stand.Draw(spritebatch);
            base.Draw(spritebatch);

            _image.Draw(spritebatch);
            foreach (Projectile l in _projectiles)
            {
                l.Draw(spritebatch);
            }
        }

        /// <summary>
        ///  checks if laser hit enemy unit
        /// </summary>
        /// <param name="units"></param>
        public void laserHitEnemy(List<Unit> units)
        {
            try
            {
                foreach (Projectile l in _projectiles)
                {
                    foreach (Unit u in units)
                    {
                        //might need to check if unit is enemy first?
                        if (l.GetRect().Intersects(u.GetRect()))
                        {
                            _projectiles.Remove(l);
                            if((u.Health = u.Health - l.Damage) <= 0)
                            {
                                u.OnDestroy();
                                units.Remove(u);
                            }
                        }
                    }
                }
            }
            catch (Exception e) { };
        }

        public void upgradeWeapon(Upgrades.ammunition x)
        {
            ammo = x;
        }
        public void upgradeDamage(Upgrades.upgrades x)
        {
            damageModifier += (int)x;
        }

        public void upgradeAttackSpeed(Upgrades.upgrades x)
        {
            speedModifier -= (float)x;
        }

        

    
    
    }
}
