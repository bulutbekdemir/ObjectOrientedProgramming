using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Homework.model.Items
{
    public class Tea : Item
    {
        private DrinkSize _size;

        public Tea(DrinkSize size)
        {
            _size = size;
            Name = "Tea";
            Price = GetPrice();
        }

        public override float GetPrice()
        {
            switch (_size)
            {
                case DrinkSize.Small:
                    return 20.0f;
                case DrinkSize.Medium:
                    return 25.0f;
                case DrinkSize.Large:
                    return 30.0f;
                default:
                    return 20.0f;
            }
        }
    }
}
