using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using RkoOuttaNowhere.Input;

namespace RkoOuttaNowhere.Screens
{
    public class SplashScreen : GameScreen
    {
        public SplashScreen()
            : base()
        {

        }

        public override void LoadContent()
        {
            base.LoadContent();

            _backgroundImage.Path = "splash_background";
            _backgroundImage.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(InputManager.Instance.KeyPressed(Keys.Enter)) 
            {
                ScreenManager.Instance.ChangeScreens(ScreenType.Title);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
