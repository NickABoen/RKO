// GameScreen.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RkoOuttaNowhere.Screens
{
    /// <summary>
    /// GameScreen represents a base class for all screens
    /// </summary>
    public class GameScreen
    {
        protected ContentManager _content;

        /// <summary>
        /// Default constructor
        /// </summary>
        public GameScreen()
        {

        }

        public virtual void LoadContent()
        {
            _content = ScreenManager.Instance.Content;
        }

        public virtual void UnloadContent()
        {
            _content.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {
            //InputManager.Instance.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}

