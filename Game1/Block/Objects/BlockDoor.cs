﻿using Microsoft.Xna.Framework;
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
    public class BlockDoor : Block, IInteractive
    {
        string Condition;
        public BlockDoor() { }
        public BlockDoor(Texture2D texture, string type, string description, Rectangle rectangle, Color color, string direction, int count, string condition)
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
            this.collide = true;
            this.desc = description;
            this.Condition = condition;           
        }

        public void Action()
        {
            throw new NotImplementedException();
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

        public void Interact(string key)//Otevření/zavření dveří.
        {
            if (key == this.Condition)
                this.collide = !collide;
            //Dodělat: přehození textury
        }

    }
}
