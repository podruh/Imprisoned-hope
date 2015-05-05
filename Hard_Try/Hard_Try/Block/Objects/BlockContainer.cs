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
    class BlockContainer : Block, IContainer
    {
        public string desc;
        public bool collide = true;
        public List<Object> content;

        public BlockContainer() { }
        public BlockContainer(Texture2D texture, string type, string description, List<Object> Content, Rectangle rectangle, Color color, string direction, int count)
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
            this.content = Content;
        }

        public BlockContainer(Texture2D texture, string type, string description, List<Object> Content, Rectangle rectangle, Color color, string direction, int count, bool collision)
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
            this.content = Content;
            this.collide = collision;
        }

        public void LightChange()
        {
            this.Lighted = !this.Lighted;
        }

        public string GetDescription()
        {
            return this.desc;
        }

        public bool GetCollision()
        {
            return this.collide;
        }

        public List<Object> GetContent()
        {
            return content;
        }

        public void Action()
        {
            throw new NotImplementedException();
        }
    }
}
