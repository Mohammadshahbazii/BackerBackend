using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Core.Entities;

public class Telephone : BaseEntity
{
    public string TellNumber { get; set; }

    public string? Description { get; set; }
}