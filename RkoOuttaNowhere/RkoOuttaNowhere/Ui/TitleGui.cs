using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
            Button newGame = new Button();
            newGame.LoadContent("ui/title/newGame", _position + _originOffset, HandleNewGame);
            _mainMenu.Buttons.Add(newGame);
            Button loadGame = new Button();
            newGame.LoadContent("ui/title/loadGame", _position + _originOffset, HandleNewGame);
            _mainMenu.Buttons.Add(newGame);
            Button options = new Button();
            newGame.LoadContent("ui/title/options", _position + _originOffset, HandleNewGame);
            _mainMenu.Buttons.Add(newGame);
            Button quit = new Button();
            newGame.LoadContent("ui/title/quit", _position + _originOffset, HandleNewGame);
            _mainMenu.Buttons.Add(newGame);
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
