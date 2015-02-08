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
        protected float _speed = 400.0f;
        protected string ammo;

        public Projectile()
        {
            _destination = Vector2.Zero;
        }

        public override void LoadContent()
        {
            _image.Path = "Gameplay/" + ammo;
            _image.Position = _position;
            _image.LoadContent();
        }

        public override void UnloadContent()
        {
            _image.UnloadContent();
        }

        public override void Update(GameTime gametime)
        {
            _image.Position += _velocity * _speed * (float)gametime.ElapsedGameTime.TotalSeconds;
            _image.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            _image.Draw(spritebatch);
        }

        public float Speed { get { return _speed; } set { _speed = value; } }
        public string Ammo { get { return ammo; } set { ammo = value; } }



    }
}
