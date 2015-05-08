using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Imprisoned_Hope
{
    [Serializable()]
    public class BlockFloor : Block, IBlock
    {
        public BlockFloor() { }

        public BlockFloor(Texture2D texture, string type, string description, Rectangle rectangle, Color color, string direction, int count)
        {
            this.Texture = texture;;
            this.Type = type;
            this.Rectangle = rectangle;
            this.X = rectangle.X;
            this.Y = rectangle.Y;
            this.Color = color;
            this.Direction = direction;
            this.Count = count;
            this.Lighted = false;
            this.desc = description;
        }

        public BlockFloor(Texture2D texture, string type, string description, Rectangle rectangle, Color color, string direction, int count, bool collision)
        {
            this.Texture = texture; ;
            this.Type = type;
            this.Rectangle = rectangle;
            this.X = rectangle.X;
            this.Y = rectangle.Y;
            this.Color = color;
            this.Direction = direction;
            this.Count = count;
            this.Lighted = false;
            this.desc = description;
            this.collide = collision;
        }

        public void LightChange()
        {
            throw new NotImplementedException();
        }

        public string GetDescription()
        {
            return desc;
        }
        public bool GetCollision()
        {
            return collide;
        }
    }
}