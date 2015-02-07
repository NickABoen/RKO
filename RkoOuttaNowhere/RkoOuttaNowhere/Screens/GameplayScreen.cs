using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using RkoOuttaNowhere.Input;
using RkoOuttaNowhere.Gameplay;
using RkoOuttaNowhere.Gameplay.Units;
using RkoOuttaNowhere.Levels;

namespace RkoOuttaNowhere.Screens
{
    public class GameplayScreen : GameScreen
    {
        private Player _player;
        private Level _currentLevel;
        public GameplayScreen()
            : base()
        {
            _player = new Player();
            _currentLevel = new Level();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            _backgroundImage.Path = "backgrounds/gameplay";
            _backgroundImage.LoadContent();
            _player.LoadContent();

            // Test level
            _currentLevel.LoadContent(2);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            _player.UnloadContent();

            _currentLevel.UnloadContent();
        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
            // Process input
            if (InputManager.Instance.KeyPressed(Keys.U))
            {
                ScreenManager.Instance.ChangeScreens(ScreenType.Upgrade);
            }
            else if (InputManager.Instance.KeyPressed(Keys.X))
            {
                ScreenManager.Instance.ChangeScreens(ScreenType.GameOver);
            }
            _player.Update(gametime);

            foreach (Wave w in _currentLevel.Waves)
                _player.laserHitEnemy(w.Units);
            // Process units
            _currentLevel.Update(gametime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            _player.Draw(spriteBatch);
            // Process units
            _currentLevel.Draw(spriteBatch);
        }
    }
}
