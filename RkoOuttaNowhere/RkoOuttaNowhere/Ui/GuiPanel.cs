// GuiPanel.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using RkoOuttaNowhere.Images;
using RkoOuttaNowhere.Screens;

namespace RkoOuttaNowhere.Ui
{
    public class GuiPanel
    {
        public Rectangle Hitbox;
        public Image Image;
        public int SelectedItem;
        [XmlElement("Button")]
        public List<Button> Buttons;
        public Vector2 Dimensions, ButtonDimensions, ButtonOffset, ButtonOrigin;
        public bool Visible;

        public GuiPanel()
        {
            Hitbox = Rectangle.Empty;
            Image = new Image();
            Buttons = new List<Button>();
            Dimensions = Vector2.Zero;
            ButtonDimensions = Vector2.Zero;
            ButtonOffset = Vector2.Zero;
            ButtonOrigin = Vector2.Zero;
            Visible = true;
        }

        public virtual void LoadContent()
        {
            ButtonOrigin += Image.Position;

            Image.LoadContent();
            int count = 0;
        }

        public virtual void UnloadContent()
        {
            Image.UnloadContent();
            foreach (Button b in Buttons)
                b.UnloadContent();
        }

        public virtual void Update(GameTime gameTime)
        {
            Image.Update(gameTime);
            foreach (Button b in Buttons)
                b.Update(gameTime);

            // Update position based on camera
            Image.Position -= ScreenManager.Instance.Camera.WorldChange;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                if(Image.Texture != null)
                    Image.Draw(spriteBatch);
                foreach (Button b in Buttons)
                    b.Draw(spriteBatch);
            }
        }

        public void HandleButtonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Console.WriteLine(b.Value);
        }
    }
}
