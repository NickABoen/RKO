using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RkoOuttaNowhere.Physics;

namespace RkoOuttaNowhere.Gameplay
{
    public abstract class Projectile:GameObject
    {
        public bool IsAlly { get; set; }
    }

    public class Laser:Projectile
    {
        private int _daamage;

        public Laser(Vector2 pos, Vector2 target)
        {

        }

        public void LoadContent() 
        {

        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gametime)
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {

        }

        public int getDamage { get { return _daamage; } set { _daamage = value; } }

        public Rectangle getRect()
        {
            return Rectangle.Empty;
        }
    }
}
