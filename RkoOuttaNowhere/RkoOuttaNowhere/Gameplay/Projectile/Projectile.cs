using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RkoOuttaNowhere.Images;
using RkoOuttaNowhere.Input;
using RkoOuttaNowhere.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RkoOuttaNowhere.Gameplay
{
    class Projectile : GameObject
    {
        protected Vector2 _destination;
        protected int damage = 50;
        protected float speed = 400.0f;

        public Projectile()
        {
            _destination = Vector2.Zero;
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

        public int getDamage { get { return damage; } }


    }
}
