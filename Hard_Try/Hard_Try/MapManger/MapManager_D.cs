using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    public partial class MapManager
    {

        public MapManager(Game1 game)
        {
            Hra = game;
            MapList = new List<Map>();
            BlockList = new List<Block>();
            TypeList = new List<string>();
            TextureList = new List<Texture2D>();
            SetTypesAndTextures();
            
        }

        public void SetTypesAndTextures()
        {
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\Brick Wall"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\floor1"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\floor2"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\floor3"));
            TypeList.Add("wall");
            TypeList.Add("Floor 1");
            TypeList.Add("Floor 2");
            TypeList.Add("Floor 3");
        }
    }
}
