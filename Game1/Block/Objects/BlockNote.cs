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
    public class BlockNote : Block, IInformational
    {
        public string message;

        public BlockNote() { }
        public BlockNote(Texture2D texture, string type, string Description, Rectangle rectangle, Color color, string Message)
        {
            this.Texture = texture; ;
            this.Type = type;
            this.Rectangle = rectangle;
            this.X = rectangle.X;
            this.Y = rectangle.Y;
            this.Color = color;
            this.Direction = "right";
            this.Count = 1;
            this.Lighted = false;
            this.desc = Description;
            this.collide = false;
            this.message = Message;
        }

        public BlockNote(Texture2D texture, string type, string Description, Rectangle rectangle, Color color, string Message, bool collision)
        {
            this.Texture = texture; ;
            this.Type = type;
            this.Rectangle = rectangle;
            this.X = rectangle.X;
            this.Y = rectangle.Y;
            this.Color = color;
            this.Direction = "right";
            this.Count = 1;
            this.Lighted = false;
            this.desc = Description;
            this.collide = collision;
            this.message = Message;
        }

        public void LightChange()
        {
            this.Lighted = !this.Lighted;
        }

        public string GetDescription()
        {
            return desc;
        }

        public bool GetCollision()
        {
            return collide;
        }

        public void Action()
        {
            throw new NotImplementedException();
        }

        public string GetMessage()
        {
            return this.message;
        }
    }
}
