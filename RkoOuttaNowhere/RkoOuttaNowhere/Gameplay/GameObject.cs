using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using RkoOuttaNowhere.Images;
using RkoOuttaNowhere.Screens;

namespace RkoOuttaNowhere.Gameplay
{
    public class GameObject
    {
        protected Vector2 _position, _velocity, _dimensions;
        public Vector2 Dimensions
        {
            get { return _dimensions; }
            set { _dimensions = value; }
        }
        protected Image _image;
        protected bool _isVisible, _isActive;

        public GameObject()
        {
            _position = _velocity = Vector2.Zero;
            _image = new Image();
            _isVisible = _isActive = true;
        }

        public virtual void LoadContent()
        {

        }

        public virtual void UnloadContent()
        {
            _image.UnloadContent();
        }

        public virtual void Update(GameTime gametime)
        {
            _image.Position = _position;
        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            _image.Draw(spritebatch);
        }

        public virtual void SetPosition(Vector2 pos)
        {
            _position = pos;
            _image.Position = pos;
        }

        public Rectangle getRect()
        {

            Rectangle r = _image.SourceRect;
            r.X = (int)_image.Position.X;
            r.Y = (int)_image.Position.Y;
            return r;
        }
    }
}
