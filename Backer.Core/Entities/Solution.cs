using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Core.Entities;

public class Solution : BaseEntity
{
    public string Title { get; set; }          
    public string? Description { get; set; }   
}