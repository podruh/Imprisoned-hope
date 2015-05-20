using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    [Serializable()]
    public class DrinkItem : Item, IItem
    {
        public int HealthGain;
        public int StaminaGain;
        public string Bonus;

        public DrinkItem()
        { 
        }

        public DrinkItem(Rectangle rectangle, Color color, int id, bool toolbar)
        {
            this.Rectangle = rectangle;
            this.Color = color;
            this.OnToolbar = toolbar;
            SetProperties(id);
        }

        public DrinkItem(Texture2D texture, Rectangle rectangle, Color color, int id, bool toolbar, int hp, int stamina)
        {
            this.Texture = texture;
            this.Rectangle = rectangle;
            this.Position = new Vector2(rectangle.X, rectangle.Y);
            this.Color = color;
            this.ID = id;
            OnToolbar = toolbar;
            this.HealthGain = hp;
            this.StaminaGain = stamina;
        }
        public DrinkItem(Texture2D texture, Rectangle rectangle, Color color, int id, bool toolbar, int hp, string bonus)
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
