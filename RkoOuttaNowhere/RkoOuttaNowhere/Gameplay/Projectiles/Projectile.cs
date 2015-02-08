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
        protected int _damage = 15;
        protected float _speed = 400.0f;

        public Projectile()
        {
            _destination = Vector2.Zero;
        }

        public void LoadContent()
        {
            _image.Path = "Gameplay/" + Upgrades.ammunition.Laser.ToString();
            _image.Position = _position;
            _image.LoadContent();
        }

        public void UnloadContent()
        {
            _image.UnloadContent();
        }

        public void Update(GameTime gametime)
        {
            _image.Position += _velocity * _speed * (float)gametime.ElapsedGameTime.TotalSeconds;
            _image.Update(gametime);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            _image.Draw(spritebatch);
        }

        public int Damage { get { return _damage; } set { _damage = value; } }
        public float Speed { get { return _speed; } set { _speed = value; } }



    }
}
