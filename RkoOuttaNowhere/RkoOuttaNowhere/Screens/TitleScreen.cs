using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using RkoOuttaNowhere.Input;
using RkoOuttaNowhere.Ui;

namespace RkoOuttaNowhere.Screens
{
    public class TitleScreen : GameScreen
    {
        public TitleScreen()
            : base()
        {
            _gui = new TitleGui();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            // Load the background image
            _backgroundImage.Path = "backgrounds/title";
            _backgroundImage.LoadContent();

            // Load the gui
            _gui.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();

            // Unload the gui
            _gui.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Update the gui
            _gui.Update(gameTime);

            // Check for key presses
            if (InputManager.Instance.KeyPressed(Keys.Enter))
            {
                ScreenManager.Instance.ChangeScreens(ScreenType.LevelSelect);
            }
            else if (InputManager.Instance.KeyPressed(Keys.U))
            {
                ScreenManager.Instance.ChangeScreens(ScreenType.Upgrade);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            
            // Draw the gui
            _gui.Draw(spriteBatch);
        }
    }
}
