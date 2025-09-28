using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Core.Entities
{
    public class Hardware : BaseEntity
    {
        public string ModelName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
