using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RkoOuttaNowhere.Screens;
using RkoOuttaNowhere.Images;

namespace RkoOuttaNowhere.Ui
{
    class GameplayGui : Gui
    {
        private GuiPanel _topBar;
        private Vector2 _position, _originOffset, _imageOffset;

        public GameplayGui()
            : base()
        {
            _panels = new List<GuiPanel>();
            _topBar = new GuiPanel();
            _position = _imageOffset = _originOffset = Vector2.Zero;
        }

        public override void LoadContent()
        {
            base.LoadContent();
            _topBar.BackgroundImage.Path = "ui/gameplay/top_bar";
            _topBar.BackgroundImage.LoadContent();

            // Add our panels
            _panels.Add(_topBar);

            // Inintialize our offsets
            _position = Vector2.Zero;
            _imageOffset = new Vector2(75, 0);
            _originOffset = new Vector2(75, 12);

            // Timer
            Image timer = new Image();
            timer.Path = "ui/gameplay/timer";
            timer.Position = _position + _originOffset;
            timer.LoadContent();
            _topBar.Images.Add(timer);
            // Text
            Image countdown = new Image();
            countdown.Path = "transparent";
            countdown.Position = _position + _originOffset + _imageOffset + new Vector2(50, 35);
            countdown.Scale = new Vector2(2, 2);
            countdown.LoadContent();
            _topBar.Images.Add(countdown);

            // Waves Remaining
            Image waves = new Image();
            waves.Path = "ui/gameplay/waves";
            waves.Position = _position + _originOffset + 3 * _imageOffset;
            waves.LoadContent();
            _topBar.Images.Add(waves);
            // Text
            Image wavesRemaining = new Image();
            wavesRemaining.Path = "transparent";
            wavesRemaining.Position = _position + _originOffset + 4 * _imageOffset + new Vector2(50, 35);
            wavesRemaining.Scale = new Vector2(2, 2);
            wavesRemaining.LoadContent();
            _topBar.Images.Add(wavesRemaining);

            // Money
            Image money = new Image();
            money.Path = "ui/gameplay/money";
            money.Position = _position + _originOffset + 6 * _imageOffset;
            money.LoadContent();
            _topBar.Images.Add(money);
            // Text
            Image currentMoney = new Image();
            currentMoney.Path = "transparent";
            currentMoney.Position = _position + _originOffset + 7 * _imageOffset + new Vector2(50, 35);
            currentMoney.Scale = new Vector2(2, 2);
            currentMoney.LoadContent();
            _topBar.Images.Add(currentMoney);

            // Health
            Image heart = new Image();
            heart.Path = "ui/gameplay/health";
            heart.Position = _position + _originOffset + 9 * _imageOffset;
            heart.LoadContent();
            _topBar.Images.Add(heart);
            // Text
            Image health = new Image();
            health.Path = "transparent";
            health.Position = _position + _originOffset + 10 * _imageOffset + new Vector2(50, 35);
            health.Scale = new Vector2(2, 2);
            health.LoadContent();
            _topBar.Images.Add(health);
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
            _topBar.Images[1].RedrawText(spriteBatch, Color.White);
            _topBar.Images[3].RedrawText(spriteBatch, Color.White);
            _topBar.Images[5].RedrawText(spriteBatch, Color.White);
            _topBar.Images[7].RedrawText(spriteBatch, Color.White);
        }

        // Set the timer to the new value
        public override void SetTimer(float countdown)
        {
            if (countdown >= 10000)
                _topBar.Images[1].Text = ((int)(countdown / 1000)).ToString();
            else if (countdown > 0)
                _topBar.Images[1].Text = (countdown / 1000).ToString("0.0");
            else
                _topBar.Images[1].Text = "0";
        }

        // Set the waves remaining to the new value
        public override void SetWaves(int waves)
        {
            _topBar.Images[3].Text = waves.ToString();
        }

        // Set the money to the new value
        public override void SetMoney(int money)
        {
            _topBar.Images[5].Text = money.ToString();
        }

        // Set the health to the new value
        public override void SetHealth(int health)
        {
            _topBar.Images[7].Text = health.ToString();
        }

        public void HandleNewGame(object sender, EventArgs e)
        {
            Console.WriteLine("New Game");
        }
    }
}
