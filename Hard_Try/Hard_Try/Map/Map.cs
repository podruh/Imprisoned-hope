using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    [Serializable()]
    public partial class Map
    {
        public string Name;
               
        public List<Block> Blocks;

        private int PosunX,PosunY;

        public Map() 
        {
            this.Blocks = new List<Block>();
            this.PosunX = 0;
            this.PosunY = 0;
        }
        public Map(string name)
        {
            this.Blocks = new List<Block>();
            this.Name = name;            
            this.PosunX = 0;
            this.PosunY = 0;
        }

        public void UpdatePosun(int x,int y)
        {
            this.PosunX = x;
            this.PosunY = y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Block item in Blocks)
            {
                item.DrawBlockLine(spriteBatch, PosunX, PosunY);
            }
        }
    }
}
