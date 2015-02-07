// ScreenManager.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using RkoOuttaNowhere.Images;

namespace RkoOuttaNowhere.Screens
{
    /// <summary>
    /// ScreenManager is a class to help facilitate screen transistions as well
    /// as manage the current screen
    /// </summary>
    public class ScreenManager
    {
        private static ScreenManager _instance;
        private GameScreen _currentScreen, _newScreen;
        private List<GameScreen> _screens;

        public Image Image;
        public Camera Camera;

        public Vector2 Dimensions { private set; get; }
        public ContentManager Content { private set; get; }
        public GraphicsDevice GraphicsDevice;
        public SpriteBatch SpriteBatch;
        public bool IsTransitioning { get; private set; }

        /// <summary>
        /// Singleton class instance
        /// </summary>
        public static ScreenManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ScreenManager();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ScreenManager()
        {
            Dimensions = new Vector2(1024, 768);
            Camera = new Camera();
            IsTransitioning = false;
            _screens = new List<GameScreen>();

            Initialize();
        }

        /// <summary>
        /// Initialize the screens
        /// </summary>
        public void Initialize()
        {
            // Create and add all of the screens
            _screens.Add(new SplashScreen());
            _screens.Add(new LevelSelectScreen());
            _screens.Add(new GameplayScreen());
            _screens.Add(new UpgradeScreen());
            _screens.Add(new GameOverScreen());
            // Set the current screen to the splash screen
            _currentScreen = _screens[(int)ScreenType.Splash];
        }

        /// <summary>
        /// Handles a screen changes
        /// </summary>
        /// <param name="screenName">name of the class to load</param>
        public void ChangeScreens(ScreenType type)
        {
            _newScreen = _screens[(int)type];
            Image.IsActive = true;
            Image.FadeEffect.Increase = true;
            Image.Alpha = 0.0f;
            IsTransitioning = true;
        }

        /// <summary>
        /// Handles a screen transition with a Fade Effect
        /// </summary>
        /// <param name="gameTime"></param>
        private void Transition(GameTime gameTime)
        {
            if (IsTransitioning)
            {
                Image.Update(gameTime);
                if (Image.Alpha == 1.0f)
                {
                    _currentScreen.UnloadContent();
                    _currentScreen = _newScreen;
                    _currentScreen.LoadContent();
                }
                else if (Image.Alpha == 0.0f)
                {
                    Image.IsActive = false;
                    IsTransitioning = false;
                }
            }
        }

        /// <summary>
        /// Loads Content
        /// </summary>
        /// <param name="Content"></param>
        public void LoadContent(ContentManager Content)
        {
            this.Content = Content;
            _currentScreen.LoadContent();
            //Image.LoadContent();
        }

        /// <summary>
        /// Unloads Content
        /// </summary>
        public void UnloadContent()
        {
            _currentScreen.UnloadContent();
            //Image.UnloadContent();
        }

        /// <summary>
        /// Update the current screen, and if necessary updates the transition
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            _currentScreen.Update(gameTime);
            Transition(gameTime);
        }

        /// <summary>
        /// Draws the current screen, and if necessary draws the transitition
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            _currentScreen.Draw(spriteBatch);
            if (IsTransitioning)
                Image.Draw(spriteBatch);
        }
    }
}

