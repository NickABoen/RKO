using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RkoOuttaNowhere.Physics
{
    [Flags]
    public enum HitBoxType
    {
        Circle,
        Rectangle
    }

    public class Circle
    {

        public float Radius { get; set; }
        public float Diameter { get { return this.Radius * 2; } set { this.Radius = value / 2; } }
        public Vector2 Center { get { return new Vector2(this.Position.X + this.Radius, this.Position.Y + this.Radius); } }

        public Vector2 Position { get; set; }

        public Circle(int x, int y, float radius)
        {
            this.Position = new Vector2((float)x, (float)y);
            this.Radius = radius;
        }

        public bool Intersects(Rectangle rect)
        {
            Vector2 v = new Vector2(MathHelper.Clamp(Center.X, rect.Left, rect.Right),
                MathHelper.Clamp(Center.Y, rect.Top, rect.Bottom));

            return Vector2.DistanceSquared(v, this.Center) < (this.Radius * this.Radius);
        }

        public bool Intersects(Circle circ)
        {
            return Vector2.DistanceSquared(circ.Center, this.Center) < (this.Radius + circ.Radius);
        }
    }

    public abstract class HitBox
    {
        Vector2 _position = Vector2.Zero;
        public Vector2 Position { get { return _position; } set { _position = value; } }
        public int RangeThreshold { get; set; }
        public abstract Rectangle Rectangle { get; }
        public abstract Circle Circle { get; }
        public abstract HitBoxType Type { get; }

        public void SetX_Pos(float value) { _position.X = value; }
        public void SetY_Pos(float value) { _position.Y = value; }
    }

    public class CircularHitBox : HitBox
    {
        public float Radius { get; set; }
        public float Diameter { get{return this.Radius*2;} set{this.Radius = value/2;} }
        public override Circle Circle { get { return new Circle((int)this.Position.X, (int)this.Position.Y, this.Radius); } }
        public override Rectangle Rectangle{get{return new Rectangle((int)this.Position.X,(int)this.Position.Y,(int)this.Diameter, (int)this.Diameter);}}
        public override HitBoxType Type { get { return HitBoxType.Circle; } }

        public CircularHitBox(Vector2 position, float radius)
        {
            this.Radius = radius;
            this.RangeThreshold = (int)this.Radius;
            this.Position = position;
        }
    }

    public class RectangularHitBox : HitBox
    {
        public int Length{get;set;}
        public int Width{get;set;}
        public override HitBoxType Type { get { return HitBoxType.Rectangle; } }
        public override Rectangle Rectangle{get{return new Rectangle((int)this.Position.X-this.Width/2,(int)this.Position.Y-this.Length/2,this.Width, this.Length);}}
        public override Circle Circle { get { return new Circle((int)this.Position.X, (int)this.Position.X, Math.Max((float)this.Length, (float)this.Width)); } }
        public RectangularHitBox(Vector2 position, int width, int length)
        {
            this.Length = length;
            this.Width = width;
            this.RangeThreshold = Math.Max(length, width);
            this.Position = position;
        }
    }
}
