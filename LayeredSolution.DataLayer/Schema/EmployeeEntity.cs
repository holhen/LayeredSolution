using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredSolution.DataLayer.Schema
{
    public class EmployeeEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Position { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Role { get; set; }
    }
}
