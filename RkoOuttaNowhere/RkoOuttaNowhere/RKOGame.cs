using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RkoOuttaNowhere
{
    public class RKOGame
    {
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
                    _finalWave, 
                    _currentLevel;
                    //add upgrades, stats, 

        /// <summary>
        /// constructor for Game class, sets initial values for game object
        /// </summary>
        /// <param name="curr"> starting curency </param>
        public RKOGame()
        {
            _currency = 100;
            _health = int.MaxValue;
            _currentLevel = 0;
            _currentWave = 0;
            //finalWave = get currentLevels maxWave

        }

        public int getCurrency { get { return _currency; } set { _currency += value; } }
        public int getHealth { get { return _health; } set { _health = value; } }
        public int getWavesLeft { get { return (_finalWave - _currentWave); } }
        public int getCurrentLevel { get { return _currentLevel; } set { _currentLevel = value; } }

        
    

    }
}
