// Level.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RkoOuttaNowhere.Gameplay.Units;

namespace RkoOuttaNowhere.Levels
{
    public class Level
    {
        private const int FIELD_SIZE = 300;
        private const int FIELD_ORIGIN = 400;

        private int _numLanes,
                    _numWaves,
                    _currentWave;

        private float _waveTimer,
                      _elapsedTime;

        private bool _levelOver,
                     _changingScrens,
                     _completed;

        private List<Wave> _waves;
        public List<Wave> Waves
        {
            get { return _waves; }
            set { _waves = value; }
        }

        private int _levelValue;
        public int LevelValue
        {
            get { return _levelValue; }
            set { _levelValue = value; }
        }

        public Level()
        {
            _waves = new List<Wave>();
        }

        public void LoadContent(int levelValue)
        {
            _levelValue = levelValue;
            _currentWave = -1;
            
            // Load the enemeies into the unit list
            List<Tuple<string, int>> list = LoadFromFile();
            foreach (Tuple<string, int> val in list)
            {
                string type = val.Item1;
                int num = val.Item2;

                switch (type)
                {
                    case "---":
                        _waves.Add(new Wave(++_currentWave, _numLanes, FIELD_SIZE, FIELD_ORIGIN));
                        break;
                    case "WeakMelee":
                        for (int i = 0; i < num; i++)
                            _waves[_currentWave].AddUnit(UnitFactory.CreateWeakMelee());
                        break;
                    case "MediumMelee":
                        for (int i = 0; i < num; i++)
                            _waves[_currentWave].AddUnit(UnitFactory.CreateMediumMelee());
                        break;
                    case "StrongMelee":
                        for (int i = 0; i < num; i++)
                            _waves[_currentWave].AddUnit(UnitFactory.CreateStrongMelee());
                        break;
                    case "WeakRanged":
                        for (int i = 0; i < num; i++)
                            _waves[_currentWave].AddUnit(UnitFactory.CreateWeakRanged());
                        break;
                    case "MediumRanged":
                        for (int i = 0; i < num; i++)
                            _waves[_currentWave].AddUnit(UnitFactory.CreateMediumRanged());
                        break;
                    case "StrongRanged":
                        for (int i = 0; i < num; i++)
                            _waves[_currentWave].AddUnit(UnitFactory.CreateStrongRanged());
                        break;
                    default:
                        throw new Exception("you cant spell for shit");
                        break;
                }
            }
            _currentWave = -1;

            foreach (Wave w in _waves)
            {
                w.LoadContent();
            }
        }

        public void UnloadContent()
        {
            foreach (Wave u in _waves)
                u.UnloadContent();
        }

        public void Update(GameTime gametime)
        {
            foreach (Wave u in _waves)
                u.Update(gametime);

            // Update the wave timer
            if (_currentWave + 1 != _numWaves)
            {
                _elapsedTime += (float)gametime.ElapsedGameTime.TotalMilliseconds;
                if (_elapsedTime >= 5000)
                {
                    _waves[++_currentWave].Activate();
                    _elapsedTime = 0;
                }
            }

            // Check for the level to be over
            if (_currentWave + 1 == _numWaves)
            {
                _levelOver = true;
                foreach (Wave w in _waves) 
                {
                    if (w.Active)
                        _levelOver = false;
                }

                if (_levelOver)
                {
                    if (!_changingScrens)
                    {
                        Screens.ScreenManager.Instance.ChangeScreens(Screens.ScreenType.LevelSelect);
                        _changingScrens = true;
                    }
                    
                }
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (Wave u in _waves)
                u.Draw(spritebatch);
        }

        /// <summary>
        /// Load from the level file and store it as a list of tuples
        /// </summary>
        /// <returns></returns>
        private List<Tuple<string, int>> LoadFromFile()
        {
            List<Tuple<string, int>> list = new List<Tuple<string, int>>();
            try
            {
                string path = "../../../Levels/Load/Level" + _levelValue + ".txt";
                string test = Directory.GetCurrentDirectory();
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        _numLanes = int.Parse(sr.ReadLine());
                        _numWaves = int.Parse(sr.ReadLine());
                        while (!sr.EndOfStream)
                        {
                            string[] vals = sr.ReadLine().Split(' ');
                            if(vals.Length == 2)
                                list.Add(new Tuple<string, int>(vals[0], int.Parse(vals[1])));
                            else
                                list.Add(new Tuple<string, int>(vals[0], 0));
                        }
                    }
                }
            }
            catch (IOException) { Console.WriteLine("Failed to read from file"); }
            catch (FormatException) { Console.WriteLine("Failed to load some enemies"); }

            return list;
        }
    }
}
