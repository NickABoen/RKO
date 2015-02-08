using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using RkoOuttaNowhere.Input;

namespace RkoOuttaNowhere.Ui
{
    public class Gui
    {
        protected List<GuiPanel> _panels;
        protected List<Rectangle> HitBoxes;

        public Gui()
        {
            _panels = new List<GuiPanel>();
            HitBoxes = new List<Rectangle>();
        }

        public virtual void LoadContent()
        {
            foreach (GuiPanel p in _panels)
            {
                p.LoadContent();
                p.Visible = false;
                HitBoxes.Add(p.Hitbox);
            }
        }

        public virtual void UnloadContent()
        {
            foreach (GuiPanel p in _panels)
                p.UnloadContent();
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (GuiPanel p in _panels)
                p.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (GuiPanel p in _panels)
                p.Draw(spriteBatch);
        }

        public virtual void SetTimer(float countdown) { }
        public virtual void SetWaves(int waves) { }
        public virtual void SetMoney(int money) { }
        public virtual void SetHealth(int health) { }

        public virtual void LoadNodes(List<Point> points, Action handler, string path) { }

        /// <summary>
        /// Return if the mouse is on the gui
        /// </summary>
        /// <returns></returns>
        public bool IsMouseOnGui()
        {
            Point m = InputManager.Instance.MousePosition;
            foreach (Rectangle r in HitBoxes)
            {
                if (r.Contains(m))
                    return true;
            }
            return false;
        }
    }
}
