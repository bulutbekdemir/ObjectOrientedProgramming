using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_info.model
{
    /// <summary>
    ///  Required fields for DB enabled models.
    /// </summary>
    /// 
    public abstract class Record
    {
        public Guid Uuid { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; private set; }

        protected Record()
        {
            Uuid = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            ModifiedAt = null;
        }

        protected void Modified()
        {
            ModifiedAt = DateTime.UtcNow;
        }
    }
}
