using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using RkoOuttaNowhere.Input;

namespace RkoOuttaNowhere.Gameplay.Units
{
    public class Unit : GameObject
    {
        private int _health, _maxHealth, _baseMoney;
        private float _moveSpeed;
        private bool _moving;
        private Behaviour _behaviour;

        public int Health 
        { 
            get { return _health; } 
            set { _health = value; } 
        }

        public Unit()
            : base()
        {
            _behaviour = Behaviour.BasicMove;
        }

        public void LoadContent(string path, Vector2 position, float movespeed, int maxHealth, int baseMoney, Behaviour behaviour)
        {
            base.LoadContent();

            _position = position;
            _image.Path = path;
            _image.Position = position;
            _image.LoadContent();
            _dimensions = new Vector2(_image.SourceRect.Width, _image.SourceRect.Height);
            _baseMoney = baseMoney;

            _moveSpeed = movespeed;
            _maxHealth = _health = maxHealth;
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

            // TODO: Remove this, added for debugging purposes
            if (InputManager.Instance.LeftMouseClick())
            {
                if (GetRect().Contains(InputManager.Instance.MousePosition))
                {
                    OnDestroy();
                }
            }

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

        public override void OnDestroy() 
        {
            _isActive = false;
        }
    }
}
