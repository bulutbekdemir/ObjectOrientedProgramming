using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Homework.model.Items
{
    public class Americano : Item
    {
        private DrinkSize _size;

        public Americano(DrinkSize size)
        {
            _size = size;
            Name = "Americano";
            Price = GetPrice();
        }

        public override float GetPrice()
        {
            switch (_size)
            {
                case DrinkSize.Small:
                    return 35.0f;
                case DrinkSize.Medium:
                    return 45.0f;
                case DrinkSize.Large:
                    return 55.0f;
                default:
                    return 35.0f;
            }
        }
    }
}
