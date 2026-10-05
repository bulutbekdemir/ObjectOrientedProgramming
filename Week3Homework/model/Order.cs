using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Homework.model
{
    class Order
    {
        public Guid Uuid { get; private set; }
        public List<Item> Items {get; set; } = new List<Item>();
        public DateTime? CompletedAt { get; private set; }

        public string TableNumber { get; set; }
        public string Employee { get; set; }
        public float Tip { get; set; }
        public float TotalAmount { get; set; }

        public Order()
        { 
            Uuid = Guid.NewGuid();
            CompletedAt = null;
        }

        public List<Item> CompleteOrder(string tableNumber, 
                                        string employee, 
                                        float tip, 
                                        float total)
        {
            TableNumber = tableNumber;
            Employee = employee;
            Tip = tip;
            TotalAmount = total;
            CompletedAt = DateTime.UtcNow;
            return this.Items;
        }
    }
}
