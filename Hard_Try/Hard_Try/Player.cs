using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    [Serializable()]
    public class Player : Sprite
    {
        public string Class;

        public int Health;

        public int PosX;

        public int PosY;

        public string OnMap;

        //doplnit místo Object typ itemů v inventáři
        public List<Object> Inventory;



        public Player()
        { 
            
        }
        

        public void SetPlayer(Texture2D texture)
        {
            this.Texture = texture;
            this.Position = new Microsoft.Xna.Framework.Vector2(PosX, PosX);
            this.Rectangle = new Microsoft.Xna.Framework.Rectangle(PosX, PosY, Texture.Width, Texture.Height);
            this.Color = Color.White;
        }

        public void PlayerUpdate()
        { 
            
        }
    }
}
