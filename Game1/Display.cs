using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    public class Display
    {
        /// <summary>
        /// Seznam komponent, které obrazovka používá
        /// </summary>
        private List<GameComponent> komponenty;
        /// <summary>
        /// Instance hry
        /// </summary>
        private Game1 hra;

        /// <summary>
        /// Vytvoří novou herní obrazovku a přidá do ní komponenty
        /// </summary>
        /// <param name="hra">Instance hry</param>
        /// <param name="komponenty">Několik komponent, které má obrazovka obsahovat</param>
        public Display(Game1 hra, params GameComponent[] komponenty)
        {
            this.hra = hra;
            this.komponenty = new List<GameComponent>();
            foreach (GameComponent komponenta in komponenty)
            {
                PridejKomponentu(komponenta);
            }
        }

        /// <summary>
        /// Přidá komponenty do herní obrazovky
        /// </summary>
        /// <param name="komponenty"></param>
        public void PridejKomponentu(GameComponent komponenta)
        {
            komponenty.Add(komponenta);
            if (!hra.Components.Contains(komponenta))
                hra.Components.Add(komponenta);
        }

        /// <summary>
        /// Vrátí komponenty herní obrazovky
        /// </summary>
        /// <returns>Pole komponent herní obrazovky</returns>
        public GameComponent[] VratKomponenty()
        {
            return komponenty.ToArray();
        }

    }
}
