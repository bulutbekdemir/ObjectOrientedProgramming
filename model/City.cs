using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_info.model
{
    /// <summary>
    ///  WHY I HAVE TO MAKE PUBLIC OTHERWISE USER CLASS
    ///  THROWS "Inconsistent accessebility property type"
    /// </summary>
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<District> Districts { get; set; } = new List<District>();
    }
}
