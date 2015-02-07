using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        public Player() : base()
        {
            _position = Vector2.Zero;
            _image = new Image();
        }

        public void LoadContent() 
        {
            _image.Path = "Gameplay/player";
            _image.Position = _position;
            _image.LoadContent();
        }
        public void UnloadContent() 
        {
            _image.UnloadContent();
        }
        public void Update(GameTime gametime) 
        {

            if (InputManager.Instance.KeyDown(Keys.Left) && _position.X > 4)
            {
                _position.X -= 5;
            }
            else if (InputManager.Instance.KeyDown(Keys.Right) && _position.X < ScreenManager.Instance.Dimensions.X - _image.SourceRect.Width)
            {
                _position.X += 5;
            }
            else if (InputManager.Instance.KeyDown(Keys.Up) && _position.Y > 4)
            {
                _position.Y -= 5;
            }
            else if (InputManager.Instance.KeyDown(Keys.Down) && _position.Y < ScreenManager.Instance.Dimensions.Y - _image.SourceRect.Height)
            {
                _position.Y += 5;
            }
            _image.Position = _position;
            _image.Update(gametime);
        }
        public void Draw(SpriteBatch spritebatch) 
        {
            _image.Draw(spritebatch);
        }
    }
}
