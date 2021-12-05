using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private ClinicDBContext _context;
        public EmployeeController(ClinicDBContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _context.Employees.ToArray();
        }
    }
}
