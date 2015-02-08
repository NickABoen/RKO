using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RkoOuttaNowhere.Levels;

namespace RkoOuttaNowhere
{
    //Add upgrades here in powers of two
    //1,2,4,8,16,32,64,128,256,512,1024,2048,4096,8192,16384,32768,65536, etc.
    [Flags]
    public enum Upgrades
    {
        None = 0
    }

    public class RKOGame
    {

        private int _currency,
                    _health,
                    _currentWave,
                    _finalWave;

        private Level _currentLevel;

        //TODO: Add other stats

        /// <summary>
        /// constructor for Game class, sets initial values for game object
        /// </summary>
        /// <param name="curr"> starting curency </param>
        public RKOGame(int curr, Level loadLevel = null)
        {
            _currency = curr;
            _health = 0;
            _currentWave = 0;

            if(loadLevel != null)
            {
                SetupLevel(loadLevel);
            }
        }

        public int Currency { get { return _currency; } set { _currency += value; } }
        public int Health { get { return _health; } set { _health = value; } }
        public int WavesLeft { get { return (_finalWave - _currentWave); } }
        public Level CurrentLevel { get { return _currentLevel; } set { _currentLevel = value; } }

        /// <summary>
        /// Setup the given level with initial values and get ready to start
        /// </summary>
        /// <param name="newLevel">Level to begin</param>
        public void SetupLevel(Level newLevel)
        {
            _currentLevel = newLevel;
            _currentWave = 0;
            //TODO: _finalWave = _currentLevel.getWaveCount;

            //TODO: make sure that everything has the right position
        }

        /// <summary>
        /// Perform cleanup operations after a level is completed or the player dies
        /// </summary>
        public void CleanLevel()
        {
            //TODO: Implement CleanLevel()
        }

        /// <summary>
        /// Effectively the update method of most of the main game features. This
        /// Is where cooldowns will occur and AI's will tick
        /// </summary>
        public void Update()
        {
            
        }

        /// <summary>
        /// Draw the elements on the game screen
        /// </summary>
        public void Draw()
        {

        }

    }
}
