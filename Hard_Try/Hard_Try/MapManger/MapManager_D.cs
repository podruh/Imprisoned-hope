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
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\grayBrick"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\grayBrick2"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\bedHead"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\bedFeet"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\JailDoors"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\JailDoors2"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\glass"));
            TextureList.Add(Hra.Content.Load<Texture2D>(@"Textury\Objects\ironBars"));
            TypeList.Add("wall");
            TypeList.Add("Floor 1");
            TypeList.Add("Floor 2");
            TypeList.Add("Floor 3");
            TypeList.Add("Gray Brick Wall");
            TypeList.Add("Gray Brick Wall 2");
            TypeList.Add("Bed Head");
            TypeList.Add("Bed Feet");
            TypeList.Add("Jail Doors");
            TypeList.Add("Jail Doors 2");
            TypeList.Add("Glass");
            TypeList.Add("Iron Bars");
        }
    }
}
