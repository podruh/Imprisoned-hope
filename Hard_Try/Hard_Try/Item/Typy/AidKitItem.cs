using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    [Serializable()]
    public class AidKitItem :Item, IItem
    {
        public int HealthGain;
        public string Bonus;

        public AidKitItem()
        {   
        }

        public AidKitItem(Rectangle rectangle, Color color, int id, bool toolbar)
        {
            this.Rectangle = rectangle;
            this.Color = color;
            this.OnToolbar = toolbar;
            SetProperties(id);
        }

        public AidKitItem(Texture2D texture, Rectangle rectangle, Color color, int id, bool toolbar, int hp)
        {
            this.Texture = texture;
            this.Rectangle = rectangle;
            this.Position = new Vector2(rectangle.X, rectangle.Y);
            this.Color = color;
            this.ID = id;
            OnToolbar = toolbar;
            this.HealthGain = hp;
        }
        public AidKitItem(Texture2D texture, Rectangle rectangle, Color color, int id, bool toolbar, int hp, string bonus)
        {
            this.Texture = texture;
            this.Rectangle = rectangle;
            this.Position = new Vector2(rectangle.X, rectangle.Y);
            this.Color = color;
            this.ID = id;
            OnToolbar = toolbar;
            this.HealthGain = hp;
            this.Bonus = bonus;
        }

        public string SetProperties(int id)
        {
            throw new NotImplementedException();
        }
    }
}
