﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
    [Serializable()]
    public class FoodItem : Item
    {
        public int HealthGain;
        public int StaminaGain;

        public FoodItem()
        { 
        
        }
    }
}