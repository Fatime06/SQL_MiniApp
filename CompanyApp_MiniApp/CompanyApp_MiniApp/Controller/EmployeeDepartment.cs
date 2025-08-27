using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp_MiniApp.Controller
{
    public class EmployeeDepartment
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeDepartment()
        {
            _employeeService = new EmployeeService();
        }

    }
}
