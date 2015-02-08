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
        /* upgrades
         * base damage - +1
         * attack speed - 
         * items?
         * wall upgrade
         * 
         */


        private List<Projectile> _lasers;
        private int damageModifier, delay = 0;
        private float speedModifier;

        public Player() : base()
        {
            _position = Vector2.Zero;
            _image = new Image();
            _lasers = new List<Projectile>();
            damageModifier = 0;
            speedModifier = 20;
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

            foreach(Projectile l in _lasers)
            {
                l.UnloadContent();
            }
        }
        public override void Update(GameTime gametime) 
        {
            base.Update(gametime);

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
            else if (InputManager.Instance.LeftMouseDown() || InputManager.Instance.LeftMouseClick())
            {
                if (delay%20 == 0)
                {
                    Projectile l = new Laser(_position, new Vector2(InputManager.Instance.MousePosition.X, InputManager.Instance.MousePosition.Y), damageModifier);
                    l.LoadContent();
                    _lasers.Add(l);
                    delay = 0;
                }
                delay++;
            }

            foreach(Projectile l in _lasers)
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
            foreach (Projectile l in _lasers)
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
                foreach (Projectile l in _lasers)
                {
                    foreach (Unit u in units)
                    {
                        //might need to check if unit is enemy first?
                        if (l.GetRect().Intersects(u.GetRect()))
                        {
                            _lasers.Remove(l);
                            if((u.Health = u.Health - l.Damage) <= 0)
                            {
                                u.OnDestroy();
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
