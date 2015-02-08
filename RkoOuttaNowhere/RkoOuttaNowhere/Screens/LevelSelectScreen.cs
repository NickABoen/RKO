using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using RkoOuttaNowhere.Input;
using RkoOuttaNowhere.Ui;

namespace RkoOuttaNowhere.Screens
{
    public class LevelSelectScreen : GameScreen
    {
        private int _currentWorld,
                    _currentLevel;

        public LevelSelectScreen()
            : base()
        {
            _gui = new LevelSelectGui();
        }

        public override void LoadContent()
        {
            base.LoadContent();

            _currentLevel = RKOGame.Instance.getCurrentLevel;
            _currentWorld = RKOGame.Instance.getCurrentWorld;

            _backgroundImage.Path = "ui/level_select/world" + (_currentWorld + 1);
            _backgroundImage.LoadContent();

            // Load all of the nodes (buttons)
            List<Point> points = LoadFromFile();
            _gui.LoadContent();
            _gui.LoadNodes(points, new Action(HandleNodeClick), "ui/level_select/Node" + (_currentWorld + 1));

            _gui.AnimateButton(_currentLevel);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();

            _gui.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (InputManager.Instance.KeyPressed(Keys.G))
            {
                ScreenManager.Instance.ChangeScreens(ScreenType.Gameplay);
            }
            else if (InputManager.Instance.KeyPressed(Keys.U))
            {
                ScreenManager.Instance.ChangeScreens(ScreenType.Upgrade);
            }

            _gui.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            _gui.Draw(spriteBatch);
        }

        public List<Point> LoadFromFile()
        {            
            List<Point> list = new List<Point>();
            string test = Directory.GetCurrentDirectory();
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
            catch(IOException) { }
            return list;
        }

        public void HandleNodeClick()
        {
            RKOGame.Instance.getCurrentLevel = _gui.NumClicked;
            ScreenManager.Instance.ChangeScreens(ScreenType.Gameplay);
        }
    }
}
