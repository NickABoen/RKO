using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using RkoOuttaNowhere.Input;
using System.IO;
using RkoOuttaNowhere.Gameplay;
using RkoOuttaNowhere.Ui;

namespace RkoOuttaNowhere.Screens
{
    public class UpgradeScreen : GameScreen
    {

        Button damageMod, healthMod;
        public UpgradeScreen()
            : base()
        {
            damageMod = new Button();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            _backgroundImage.Path = "backgrounds/upgrade";
            _backgroundImage.LoadContent();
            damageMod.LoadContent("ui/level_select/Node1", new Vector2(300.0f, 300.0f), upgradeDamage);
        }

       

        public override void UnloadContent()
        {
            base.UnloadContent();
            damageMod.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (InputManager.Instance.KeyPressed(Keys.G))
            {
                ScreenManager.Instance.ChangeScreens(ScreenType.Gameplay);
            }
            else if (InputManager.Instance.KeyPressed(Keys.L))
            {
                ScreenManager.Instance.ChangeScreens(ScreenType.LevelSelect);
            }
            damageMod.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            damageMod.Draw(spriteBatch);
        }


        public void upgradeDamage(Object o, EventArgs e)
        {
            Upgrade.DamageBoost += .25f;
        }







    }
}
