using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RkoOuttaNowhere.Gameplay.Units
{
    public class Unit : GameObject
    {
        private int _health, _maxHealth;
        private float _moveSpeed;
        private bool _moving;
        private Behaviour _behaviour;

        public Unit()
            : base()
        {
            _behaviour = Behaviour.BasicMove;
        }

        public void LoadContent(string path, Vector2 position, float movespeed, int maxHealth, Behaviour behaviour)
        {
            base.LoadContent();

            _position = position;
            _image.Path = path;
            _image.Position = position;
            _image.LoadContent();

            _moveSpeed = movespeed;
            _maxHealth = maxHealth;
            _behaviour = behaviour;
            _moving = true;
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);

            if (_moving)
            {
                if (_behaviour == Behaviour.BasicMove)
                {
                    _position.X += (float)(_moveSpeed * gametime.ElapsedGameTime.TotalSeconds);
                }
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
        }
    }
}
