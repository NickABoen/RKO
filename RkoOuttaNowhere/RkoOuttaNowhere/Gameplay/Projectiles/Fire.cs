using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RkoOuttaNowhere.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RkoOuttaNowhere.Physics;

namespace RkoOuttaNowhere.Gameplay.Projectiles
{
     class Fire : Projectile
    {
        public Fire(Vector2 start, Vector2 dest, int dmg)
        {
            _position = start;
            _velocity = dest - start;
            if (_velocity != Vector2.Zero)
                _velocity.Normalize();
            _image = new Image();
            Damage = dmg;
        }

        public void LoadContent(bool isAlly = false) 
        {
            _image.Path = "Gameplay/Fire";
            _image.Position = _position;
            _image.LoadContent();
            this.IsAlly = isAlly;
            this.HitBox = new CircularHitBox(_position, Math.Max(_image.SourceRect.Width, _image.SourceRect.Height));
            PhysicsManager.Instance.AddProjectile(this);
        }

        public void UnloadContent() 
        {
            _image.UnloadContent();
        }

        public void Update(GameTime gametime) 
        {
            this.HitBox.Position += _velocity * _speed * (float)gametime.ElapsedGameTime.TotalSeconds;
            _image.Position = this.HitBox.Position;
            _image.Update(gametime);            
        }

        public void Draw(SpriteBatch spritebatch) 
        {
            _image.Draw(spritebatch);
        }
    }
}
