using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    [Serializable()]
    public class ToolItem :Item, IItem
    {
        public int Damage;

        public ToolItem()
        { 
        }
        public ToolItem(Rectangle rectangle, Color color, int id, bool toolbar)
        {
            this.Rectangle = rectangle;
            this.Color = color;
            this.OnToolbar = toolbar;
            SetProperties(id);
        }

        public ToolItem(Texture2D texture, Rectangle rectangle, Color color, int id, bool toolbar, string type, int damage)
        {
            this.Texture = texture;
            this.Rectangle = rectangle;
            this.Position = new Vector2(rectangle.X, rectangle.Y);
            this.Color = color;
            this.ID = id;
            OnToolbar = toolbar;
            this.Damage = damage;
        }

        public string SetProperties(int id)
        {
            throw new NotImplementedException();
        }
    }
}
