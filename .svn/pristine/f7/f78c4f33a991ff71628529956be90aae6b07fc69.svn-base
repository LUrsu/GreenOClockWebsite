using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GreenOClock.Data;

namespace GreenOClock.Services
{
    public class EmployeeTypeService : Service<EmployeeType, GreenOClockEntities>
    {
        public EmployeeType DefaultType()
        {
            return EmployeeType();
        }

        public EmployeeType OwnerType()
        {
            return All().First(et => et.Name.Equals("Owner", StringComparison.InvariantCultureIgnoreCase));
        }

        public EmployeeType ManagerType()
        {
            return All().First(et => et.Name.Equals("Manager", StringComparison.InvariantCultureIgnoreCase));
        }

        public EmployeeType EmployeeType()
        {
            return All().First(et => et.Name.Equals("Employee", StringComparison.InvariantCultureIgnoreCase));
        }

        public EmployeeType ById(int id)
        {
            return All().First(et => et.Id == id);
        }
    }
}
