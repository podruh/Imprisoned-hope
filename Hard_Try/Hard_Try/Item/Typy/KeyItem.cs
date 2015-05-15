using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    [Serializable()]
    public class KeyItem : Item, IItem
    {
        public string Password;

        public KeyItem()
        {       
        }
        public KeyItem(Rectangle rectangle, Color color, int id, bool toolbar, string password)
        {
            this.Rectangle = rectangle;
            this.Color = color;
            this.OnToolbar = toolbar;
            this.Password = password;
            SetProperties(id);
        }

        public KeyItem(Texture2D texture, Rectangle rectangle, Color color, int id, bool toolbar, string password)
        {
            this.Texture = texture;
            this.Rectangle = rectangle;
            this.Position = new Vector2(rectangle.X, rectangle.Y);
            this.Color = color;
            this.ID = id;
            OnToolbar = toolbar;
            this.Password = password;
        }

        public string SetProperties(int id)
        {
            throw new NotImplementedException();
        }
    }
}
