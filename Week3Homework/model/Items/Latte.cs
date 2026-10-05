using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Homework.model.Items
{
    public class Latte : Item
    {
        private DrinkSize _size;

        public Latte(DrinkSize size)
        {
            _size = size;
            Name = "Latte";
            Price = GetPrice();
        }

        public override float GetPrice()
        {
            switch (_size)
            {
                case DrinkSize.Small:
                    return 45.0f;
                case DrinkSize.Medium:
                    return 55.0f;
                case DrinkSize.Large:
                    return 65.0f;
                default:
                    return 45.0f;
            }
        }
    }
}
