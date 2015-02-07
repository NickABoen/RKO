using Microsoft.Xna.Framework;
using RkoOuttaNowhere.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RkoOuttaNowhere
{
    public abstract class GameObject
    {
        protected Vector2 position;
        protected Image image;
        protected bool _isActive, _isVisible;

    }
}
