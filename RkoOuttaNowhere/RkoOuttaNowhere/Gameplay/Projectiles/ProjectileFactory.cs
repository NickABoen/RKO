﻿using Microsoft.Xna.Framework;
using RkoOuttaNowhere.Gameplay.Projectiles;
using RkoOuttaNowhere.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RkoOuttaNowhere.Gameplay
{
    class ProjectileFactory
    {
        public const int GUN_DAMAGE = 5;
        public const int FIRE_DAMAGE = 10;
        public const int LASER_DAMAGE = 15;

        public static Projectile Shoot(Vector2 _position, int damageMod, Upgrades.ammunition x)
        {
            if (Upgrades.ammunition.Laser == x)
                return CreateLaserShot(_position, damageMod);
            else if (Upgrades.ammunition.Fire == x)
                return CreateFireShot(_position, damageMod);
            else if (Upgrades.ammunition.Gun == x)
                return CreateGunShot(_position, damageMod);
            return null;
        }

        public static Projectile CreateGunShot(Vector2 _position, int damageMod)
        {
            return null;
        }

        public static Projectile CreateFireShot(Vector2 _position, int damageMod)
        {
            Fire f = new Fire(_position, new Vector2(InputManager.Instance.MousePosition.X, InputManager.Instance.MousePosition.Y), FIRE_DAMAGE + damageMod);
            f.LoadContent();
            return f;
        }

        public static Projectile CreateLaserShot(Vector2 _position, int damageMod)
        {
            Laser l = new Laser(_position, new Vector2(InputManager.Instance.MousePosition.X, InputManager.Instance.MousePosition.Y), LASER_DAMAGE + damageMod);
            l.LoadContent();
            return l;
        }
    }
}
