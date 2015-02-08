using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        private List<Laser> _lasers;
        public Player() : base()
        {
            _position = Vector2.Zero;
            _image = new Image();
            _lasers = new List<Laser>();
        }

        public override void LoadContent() 
        {
            base.LoadContent();
            _image.Path = "Gameplay/player";
            _image.Position = _position;
            _image.LoadContent();
        }
        public override void UnloadContent() 
        {
            base.UnloadContent();

            foreach(Laser l in _lasers)
            {
                l.UnloadContent();
            }
        }
        public override void Update(GameTime gametime) 
        {
            base.Update(gametime);

            if (InputManager.Instance.KeyDown(Keys.Left) && _position.X > 4)
            {
                //YARRR code were changed here!
                Vector2 temp = _position;
                temp.X -= 5;
                _position = temp;
            }
            else if (InputManager.Instance.KeyDown(Keys.Right) && _position.X < ScreenManager.Instance.Dimensions.X - _image.SourceRect.Width)
            {
                Vector2 temp = _position;
                temp.X += 5;
                _position = temp;
            }
            else if (InputManager.Instance.KeyDown(Keys.Up) && _position.Y > 4)
            {
                Vector2 temp = _position;
                temp.Y -= 5;
                _position = temp;
            }
            else if (InputManager.Instance.KeyDown(Keys.Down) && _position.Y < ScreenManager.Instance.Dimensions.Y - _image.SourceRect.Height)
            {
                Vector2 temp = _position;
                temp.Y += 5;
                _position = temp;
            }
            else if (InputManager.Instance.LeftMouseClick())
            {
                Laser l = new Laser(_position, new Vector2(InputManager.Instance.MousePosition.X, InputManager.Instance.MousePosition.Y));
                l.LoadContent();
                _lasers.Add(l);
            }

            foreach(Laser l in _lasers)
            {
                l.Update(gametime);
            }
            _image.Position = _position;
            _image.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch) 
        {
            base.Draw(spritebatch);

            _image.Draw(spritebatch);
            foreach (Laser l in _lasers)
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
                foreach (Laser l in _lasers)
                {
                    foreach (Unit u in units)
                    {
                        Rectangle r1 = l.getRect(), r2 = u.GetRect();
                        //might need to check if unit is enemy first?
                        if (l.getRect().Intersects(u.GetRect()))
                        {
                            _lasers.Remove(l);
                            if((u.Health = u.Health - l.getDamage) <= 0)
                            {
                                units.Remove(u);
                            }
                        }
                    }
                }
            }
            catch (Exception e) { };
        }

    
    
    }
}
