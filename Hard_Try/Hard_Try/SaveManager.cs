using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Xml.Serialization;

namespace Imprisoned_Hope
{
    public class SaveManager
    {
        private List<Save> Saves;

        private Game1 Hra;


        public SaveManager(Game1 game)
        {
            Hra = game;
        }

        public void LoadSaves()
        {
            if (File.Exists("saves.xml"))
            {
                XmlSerializer ser = new XmlSerializer(Saves.GetType());
                StreamReader sr= new StreamReader("saves.xml");
                Saves = (List<Save>)ser.Deserialize(sr);
                sr.Close();
                foreach (Save item in Saves)
                {
                    SetPlayer(item);
                }
            }
        }

        public void SaveSaves()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(Saves.GetType());
                StreamWriter sw = new StreamWriter("saves.xml");
                ser.Serialize(sw, Saves);
                sw.Close();
            }
            catch (Exception ex)
            {
                throw;

            }
        
        }

        public void SetPlayer(Save save)
        {
            save.SetPlayer(Hra.Content.Load<Texture2D>(@"Textury\Hero"));
        }

        public void AddSave(Save save)
        {
            if (Saves.Contains(save))
            {
                UpdateSave(save);
            }
            else
            {
                SetPlayer(save);
                Saves.Add(save);
                
            }
            
        }

        public void UpdateSave(Save save)
        {
            foreach (Save item in Saves)
            {
                if (item.Name == save.Name)
                {
                    Saves.Remove(item);
                    Saves.Add(save);
                    break;
                }
            }
        }
    }
}
