using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Core.Entities;

public class Difficult : BaseEntity
{
    public string Description { get; set; }
    public int DifficultGroupId { get; set; }
    public DifficultGroup DifficultGroup { get; set; } // Navigation property
}
