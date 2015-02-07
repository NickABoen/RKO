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

        private int _numLanes;
        private int _unitStagger;

        private List<Unit> _units;
        public List<Unit> Units
        {
            get { return _units; }
            set { _units = value; }
        }

        private int _levelValue;
        public int LevelValue
        {
            get { return _levelValue; }
            set { _levelValue = value; }
        }

        public Level()
        {
            _units = new List<Unit>();
        }

        public void LoadContent(int levelValue)
        {
            _levelValue = levelValue;
            
            // Load the enemeies into the unit list
            List<Tuple<string, int>> list = LoadFromFile();
            foreach (Tuple<string, int> val in list)
            {
                string type = val.Item1;
                int num = val.Item2;

                switch (type)
                {
                    case "WeakMelee":
                        for (int i = 0; i < num; i++)
                            _units.Add(UnitFactory.CreateWeakMelee());
                        break;
                    case "MediumMelee":
                        for (int i = 0; i < num; i++)
                            _units.Add(UnitFactory.CreateMediumMelee());
                        break;
                    case "StrongMelee":
                        for (int i = 0; i < num; i++)
                            _units.Add(UnitFactory.CreateStrongMelee());
                        break;
                    case "WeakRanged":
                        for (int i = 0; i < num; i++)
                            _units.Add(UnitFactory.CreateWeakRanged());
                        break;
                    case "MediumRanged":
                        for (int i = 0; i < num; i++)
                            _units.Add(UnitFactory.CreateMediumRanged());
                        break;
                    case "StrongRanged":
                        for (int i = 0; i < num; i++)
                            _units.Add(UnitFactory.CreateStrongRanged());
                        break;
                    default:
                        _units.Add(new Unit());
                        break;
                }
            }

            // Create the y values for the lanes
            int offset = FIELD_SIZE / (_numLanes + 1);
            _unitStagger = 50;


            // Assign the units to a random lane
            Random r = new Random();
            int count = 0;
            foreach (Unit u in _units)
            {
                int lane = r.Next(_numLanes - 1);
                u.SetPosition(new Vector2(0 - count * _unitStagger - u.Dimensions.X, FIELD_ORIGIN + lane * offset));
                count++;
            }
        }

        public void UnloadContent()
        {
            foreach (Unit u in _units)
                u.UnloadContent();
        }

        public void Update(GameTime gametime)
        {
            foreach (Unit u in _units)
                u.Update(gametime);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (Unit u in _units)
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
                        while (!sr.EndOfStream)
                        {
                            string[] vals = sr.ReadLine().Split(' ');
                            list.Add(new Tuple<string, int>(vals[0], int.Parse(vals[1])));
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
