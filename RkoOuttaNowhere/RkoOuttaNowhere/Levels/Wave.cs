using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RkoOuttaNowhere.Gameplay.Units;

namespace RkoOuttaNowhere.Levels
{
    public class Wave
    {
        private List<Unit> _units;
        // Different from _isActive, deals with wave timer
        private bool _active;
        private int _waveValue,
                    _numLanes,
                    _fieldSize,
                    _unitStagger,
                    _fieldOrigin,
                    _unitsAlive;
        
        
        public int WaveValue
        {
            get { return _waveValue; }
            set { _waveValue = value; }
        }
        public List<Unit> Units
        {
            get { return _units; }
            set { _units = value; }
        }
        // Different from _isActive, deals with wave timer
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public Wave(int waveValue, int numlanes, int fieldSize, int fieldOrigin)
        {
            _units = new List<Unit>();
            _waveValue = waveValue;
            _numLanes = numlanes;
            _fieldSize = fieldSize;
            _fieldOrigin = fieldOrigin;
        }

        public void LoadContent()
        {
            // Create the y values for the lanes
            int offset = _fieldSize / (_numLanes + 1);
            _unitStagger = 50;


            // Assign the units to a random lane
            int count = 0;
            foreach (Unit u in _units)
            {
                u.SetPosition(new Vector2(0 - (count / _numLanes) * _unitStagger - u.Dimensions.X, _fieldOrigin + (count % _numLanes * offset)));
                count++;
            }
            _unitsAlive = _units.Count;
        }

        public void UnloadContent()
        {
            foreach (Unit u in _units)
                u.UnloadContent();
        }

        public void Update(GameTime gametime)
        {
            if (_active)
            {
                foreach (Unit u in _units)
                {
                    u.Update(gametime);
                }

                // Remove any inactive units
                _units.RemoveAll(unit => !unit.IsActive);
                // Check for the wave to be dead
                if (_units.Count == 0)
                {
                    _active = false;
                }
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if (_active)
            {
                foreach (Unit u in _units)
                    u.Draw(spritebatch);
            }
        }

        public void AddUnit(Unit u) 
        {
            _units.Add(u);
        }

        public void Activate()
        {
            _active = true;
        }
    }
}