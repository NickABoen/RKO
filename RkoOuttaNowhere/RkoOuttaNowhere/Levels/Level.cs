using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using RkoOuttaNowhere.Gameplay.Units;

namespace RkoOuttaNowhere.Levels
{
    public class Level
    {
        private List<Unit> _units;
        [XmlElement("Unit")]
        public List<Unit> Units
        {
            get { return _units; }
            set { _units = value; }
        }

        public Level()
        {
            _units = new List<Unit>();
        }
    }
}
