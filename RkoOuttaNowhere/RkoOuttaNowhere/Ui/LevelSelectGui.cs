using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RkoOuttaNowhere.Ui
{
    public class LevelSelectGui : Gui
    {
        private List<Button> _nodes;
        private Action _nodeHandler;

        public LevelSelectGui()
            : base()
        {
            _nodes = new List<Button>();
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (Button b in _nodes)
                b.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            foreach (Button b in _nodes)
                b.Draw(spriteBatch);
        }

        public override void LoadNodes(List<Point> points, Action handler, string path)
        {
            _nodeHandler = handler;

            int count = 0;
            foreach (Point p in points)
            {
                Button b = new Button();
                b.LoadContent(path, new Vector2(p.X, p.Y), HandleNodeClick);
                b.CenterImages();
                b.Images[0].ActivateEffect("SpriteSheetEffect");
                b.Images[0].SpriteSheetEffect.AmountOfFrames = new Vector2(2, 1);
                b.Images[0].SpriteSheetEffect.CurrentFrame = Vector2.Zero;
                b.Value = count++;
                b.HitBox = new Rectangle((int)b.Images[0].Position.X, (int)b.Images[0].Position.Y, 32, 32);
                _nodes.Add(b);
            }
        }

        public void HandleNodeClick(object sender, EventArgs e)
        {
            _numClicked = (int)((Button)(sender)).Value;
            _nodeHandler();
        }

        public override void AnimateButton(int index)
        {
            _nodes[index].Images[0].IsActive = true;
        }
    }
}
