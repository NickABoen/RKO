using Microsoft.Xna.Framework;
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

        public static Projectile CreateGunShot()
        {
            return null;
        }

        public static Projectile CreateFireShot()
        {
            return null;
        }

        public static Projectile CreateLaserShot(Vector2 _position)
        {
            Projectile l = new Laser(_position, new Vector2(InputManager.Instance.MousePosition.X, InputManager.Instance.MousePosition.Y), LASER_DAMAGE);
            l.LoadContent();
            return l;
        }
    }
}
