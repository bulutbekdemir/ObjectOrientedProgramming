using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Homework.model
{
    public enum DrinkSize
    {
        Small,
        Medium,
        Large
    }
    public class Item : I_Item
    {
        public string Name { get; protected set; }
        public float Price { get; protected set; }

        public virtual string GetName() => Name;
        public virtual float GetPrice() => Price;
    }
}
