using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Imprisoned_Hope
{
    [Serializable()]
    [XmlInclude(typeof(Item))]
    [XmlInclude(typeof(FoodItem))]
    [XmlInclude(typeof(DrinkItem))]
    [XmlInclude(typeof(KeyItem))]
    [XmlInclude(typeof(AidKitItem))]
    [XmlInclude(typeof(ToolItem))]
    [XmlInclude(typeof(WeaponItem))]
    public class Item : Sprite
    {
        public string Type;
        public string Name;

        public Item()
        { 
            
        }
    }
}
