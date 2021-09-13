using Employee.Core.Repositories;
using Employee.Infrastructure.Data;
using Employee.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee.Core.Entities.Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Core.Entities.Employee>> GetEmployeeByLastName(string lastname)
        {
            return await _context.Employees.Where(e => e.LastName == lastname).ToListAsync();
        }
    }
}
