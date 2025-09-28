using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Core.Entities;

public class Software : BaseEntity
{
    public string SoftwareName { get; set; }
    public DateTime? CreateDate { get; set; }  // Nullable for "Checked" in DB
    public string? Description { get; set; }   // Nullable for "Checked" in DB
    public bool IsActive { get; set; }
}