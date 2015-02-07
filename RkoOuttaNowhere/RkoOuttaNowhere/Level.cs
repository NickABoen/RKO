using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RkoOuttaNowhere
{
    class Level
    {
        private string _levelName;
        private int _waveCount;
        //other stuff?

        public Level(string name, int count)
        {
            _levelName = name;
            _waveCount = count;
        }

        public string getLevel{ get { return _levelName;} set{ _levelName = value;} }
        public int getWaveCount { get { return _waveCount; } set { _waveCount = value; } }

    }
}
