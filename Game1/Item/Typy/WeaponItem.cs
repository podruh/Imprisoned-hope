using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    [Serializable()]
    public class WeaponItem : Item
    {
        public int Damage;


        public WeaponItem()
        { 
        
        }

        public override void ItemUpdate(Game1 game, KeyboardState key, MouseState mys)
        {

        }
    }
}
