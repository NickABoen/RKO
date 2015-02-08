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

        Button b;
        public UpgradeScreen()
            : base()
        {
            b = new Button();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            _backgroundImage.Path = "backgrounds/upgrade";
            _backgroundImage.LoadContent();
            b.LoadContent("ui/level_select/Node1", new Vector2(300.0f, 300.0f), upgradeDamage);
        }

        public void upgradeDamage(Object o, EventArgs e)
        {
            Upgrade.DamageBoost += 5.0f;
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            b.UnloadContent();
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
            b.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            b.Draw(spriteBatch);
        }





        public List<Point> LoadFromFile()
        {
            List<Point> list = new List<Point>();
            string path = "../../../Content/ui/level_select/world1_coor.txt";
            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (!sr.EndOfStream)
                        {
                            string[] vals = sr.ReadLine().Split(',');
                            list.Add(new Point(int.Parse(vals[0]), int.Parse(vals[1])));
                        }
                    }
                }
            }
            catch (IOException) { }
            return list;
        }

        public void HandleNodeClick()
        {
            if (_gui.NumClicked == 0)
            {
                Upgrade.DamageBoost += .25f;
            }
        }



    }
}
