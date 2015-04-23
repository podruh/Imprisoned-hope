using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    [Serializable()]
    public class Map
    {
        public string Name;
        
        private int PosunX, PosunY;        
        
        public List<Block> Blocks;

        public Map() 
        {
            this.Blocks = new List<Block>();
            this.PosunX = 0;
            this.PosunY = 0;
        }
        public Map(string name)
        {
            this.Name = name;
            this.Blocks = new List<Block>();
            this.PosunX = 0;
            this.PosunY = 0;
        }


        public void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            foreach (Block item in Blocks)
            {
                item.DrawBlockLine(spriteBatch, PosunX, PosunY);
            }
        }
    }
}
