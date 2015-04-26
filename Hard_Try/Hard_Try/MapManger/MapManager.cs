using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;
using System.IO;

namespace Imprisoned_Hope
{
    public partial class MapManager
    {
        private List<Map> MapList;

        private List<Block> BlockList;

        private List<string> TypeList;

        private List<Texture2D> TextureList;

        private Game1 Hra;

        private BuilderComponent BC;

        public MapManager()
        {
            MapList = new List<Map>();
            BlockList = new List<Block>(); 
            TypeList = new List<string>();
            TextureList = new List<Texture2D>();
        }

        public MapManager(List<Map> maps, List<string> types, List<Texture2D> textures, Game1 game)
        {
            this.MapList = maps;
            this.TypeList = types;
            this.TextureList = textures;
            Hra = game;
        }

        public MapManager(List<Map> maps, List<string> types, List<Texture2D> textures, BuilderComponent bc)
        {
            this.MapList = maps;
            this.TypeList = types;
            this.TextureList = textures;
            this.BC = bc;
        }
        /// <summary>
        /// uloží všechny mapy v MapList
        /// </summary>
        public void Ulozit()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(MapList.GetType());
                StreamWriter sw = new StreamWriter("maps.xml");
                ser.Serialize(sw, MapList);
                sw.Close();
            }
            catch (Exception ex)
            {
                if (BC != null)
                {
                    BC.Message(ex.Message);
                }
                else
                {
                    throw;
                }
                
            }
        }
        /// <summary>
        /// nahraje všechny mapy v souboru maps.xml a nastaí jim textury podle typu
        /// </summary>
        public void Nahrat()
        {
            try
            {
                if (File.Exists("maps.xml"))
                {
                    XmlSerializer ser = new XmlSerializer(MapList.GetType());
                    StreamReader sr = new StreamReader("maps.xml");
                    MapList = (List<Map>)ser.Deserialize(sr);
                    sr.Close();
                    //nastavení textur
                    foreach (Map map in MapList)
                    {
                        SetBlocks(map);
                    }
                }
            }
            catch (Exception ex)
            {
                if (BC != null)
                {
                    BC.Message(ex.Message);
                }
                else
                {
                    throw;
                }
                
            }
        }
        /// <summary>
        /// vrátí mapu podle daného jména
        /// </summary>
        /// <param name="name">jméno žádané mapy</param>
        /// <returns>Vrací objekt mapy</returns>

        public Map GetMapByName(string name)
        {
            foreach (Map map in MapList)
            {
                if (map.Name == name)
                {
                    return map;
                }
            }
            return null;
        }
        /// <summary>
        /// vrátí list jmen map
        /// </summary>
        /// <returns></returns>
        public List<string> GetMapNameList()
        {
            List<string> names = new List<string>();
            foreach (Map map in MapList)
            {
                names.Add(map.Name);
            }
            return names;
        }
        /// <summary>
        /// vrátí pole jsem map
        /// </summary>
        /// <returns></returns>
        public string[] GetMapNameArray()
        {
            string[] names = new string[MapList.Count];
            int i = 0;
            foreach (Map map in MapList)
            {
                names[i] = map.Name;
                i++;
            }
            return names;
        }
        /// <summary>
        /// přidá texturu do listu 
        /// </summary>
        /// <param name="texture"></param>
        public void AddTexture(params Texture2D[] texture)
        {
            TextureList.AddRange(texture);
        }
        /// <summary>
        /// přidá typ do listu
        /// </summary>
        /// <param name="type"></param>
        public void AddType(params string[] type)
        {
            TypeList.AddRange(type);
        }
        /// <summary>
        /// přidá blok do listu
        /// </summary>
        /// <param name="block"></param>
        public void AddBlock(params Block[] block)
        {
            BlockList.AddRange(block);
        }
        /// <summary>
        /// přidá mapu do listu, jestliže již existuje, přepíše ji
        /// </summary>
        /// <param name="map"></param>
        public void AddMap(Map map)
        {
            if (MapList.Contains(map))
            {
                UpdateMap(map);
            }
            else
            {
                MapList.Add(map);
            }
        }
        /// <summary>
        /// nahrazení staré verze mapy za novou
        /// </summary>
        /// <param name="map"></param>
        public void UpdateMap(Map map)
        {            
            foreach (Map item in MapList)
            {
                if (item.Name == map.Name)
                {
                    MapList.Remove(item);
                    MapList.Add(map);
                    break;
                }
            }
        }
        /// <summary>
        /// vykreslí mapu podle jména mapy
        /// </summary>
        /// <param name="name">jméno mapy</param>
        /// <param name="sb">SpriteBatch</param>
        public void DrawMapByName(string name,SpriteBatch sb)
        {
            Map map = GetMapByName(name);
            map.Draw(sb);
        }
        /// <summary>
        /// vrátí texturu z TextureList podle zadaného typu
        /// </summary>
        /// <param name="type">Typ bloku</param>
        /// <returns></returns>
        public Texture2D GetTexture2DByType(string type)
        {
            for (int i = 0; i < TypeList.Count; i++)
            {
                if (TypeList[i] == type)
                {
                    return TextureList[i];
                }                
            }
            return null;
        }
        /// <summary>
        /// nastaví textury blokům z dané mapy
        /// </summary>
        /// <param name="map">mapa která potřebuje načíst bloky</param>
        public void SetBlocks(Map map)
        {
            foreach (Block item in map.Blocks)
            {
                item.SetTextures(GetTexture2DByType(item.Type),GetTexture2DByType(item.Type));               
            }
        }
    }
}
