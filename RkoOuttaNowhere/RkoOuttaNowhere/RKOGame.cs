using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RkoOuttaNowhere
{
    public class RKOGame
    {
        public const int NUM_LEVELS = 30;

        private static RKOGame _instance;
        /// <summary>
        /// Singleton class instance
        /// </summary>
        public static RKOGame Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RKOGame();
                }
                return _instance;
            }
        }

        private int _currency, 
                    _health, 
                    _currentWave,
                    _currentWorld,
                    _finalWave, 
                    _currentLevel,
                    _highestCompletedLevel;
                    //add upgrades, stats, 

        private Screens.ScreenType _lastScreen;
        public Screens.ScreenType LastScreen
        {
            get { return _lastScreen; }
            set { _lastScreen = value; }
        }
        /// <summary>
        /// constructor for Game class, sets initial values for game object
        /// </summary>
        /// <param name="curr"> starting curency </param>
        private RKOGame()
        {
            _currency = 100;
            _health = int.MaxValue;
            _currentLevel = 0;
            _currentWave = 0;
            //finalWave = 30;

        }

        public int getCurrency { get { return _currency; } set { _currency += value; } }
        public int getHealth { get { return _health; } set { _health = value; } }
        public int getWavesLeft { get { return (_finalWave - _currentWave); } }
        public int getCurrentLevel { get { return _currentLevel; } set { _currentLevel = value; } }
        public int getCurrentWorld { get { return _currentWorld; } set { _currentWorld = value; } }
        public int getHighestCompletedLevel { get { return _highestCompletedLevel; } set { _highestCompletedLevel = value; } }

        
    

    }
}
