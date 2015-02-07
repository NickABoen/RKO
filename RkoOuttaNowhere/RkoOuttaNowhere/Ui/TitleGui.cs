using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RkoOuttaNowhere.Screens;

namespace RkoOuttaNowhere.Ui
{
    class TitleGui : Gui
    {
        private GuiPanel _mainMenu;
        private Vector2 _position, _originOffset, _buttonOffset;

        public TitleGui()
            : base()
        {
            _panels = new List<GuiPanel>();
            _mainMenu = new GuiPanel();
            _position = _buttonOffset = _originOffset = Vector2.Zero;
        }

        public override void LoadContent()
        {
            base.LoadContent();
            // Add our panels
            _panels.Add(_mainMenu);

            // Create the new game, load game, options, and quit buttons
            _position = new Vector2(ScreenManager.Instance.Dimensions.X / 2 - 171, ScreenManager.Instance.Dimensions.Y / 2 - 25);
            _buttonOffset = new Vector2(0, 100);
            _originOffset = new Vector2(0, 0);

            Button newGame = new Button();
            newGame.LoadContent("ui/title/newGame", _position + _originOffset, HandleNewGame);
            _mainMenu.Buttons.Add(newGame);
            Button loadGame = new Button();
            loadGame.LoadContent("ui/title/loadGame", _position + _originOffset + _buttonOffset, HandleNewGame);
            _mainMenu.Buttons.Add(loadGame);
            Button options = new Button();
            options.LoadContent("ui/title/options", _position + _originOffset + 2 * _buttonOffset, HandleNewGame);
            _mainMenu.Buttons.Add(options);
            Button quit = new Button();
            quit.LoadContent("ui/title/quit", _position + _originOffset + 3 * _buttonOffset, HandleNewGame);
            _mainMenu.Buttons.Add(quit);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void HandleNewGame(object sender, EventArgs e)
        {
            Console.WriteLine("New Game");
        }
    }
}
