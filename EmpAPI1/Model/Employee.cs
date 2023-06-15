using Microsoft.EntityFrameworkCore;

using System;

using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using System.Linq;

using System.Threading.Tasks;
namespace EmpAPI1.Model
{
    public class Employee
    {
        [Key]
            public int EmpId { get; set; }
            public string Name { get; set; }
            public string Dept { get; set; }
            public string Address { get; set; }
    }
}
