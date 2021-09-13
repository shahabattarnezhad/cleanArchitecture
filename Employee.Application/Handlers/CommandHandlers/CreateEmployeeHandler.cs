using Employee.Application.Commands;
using Employee.Application.Mappers;
using Employee.Application.Responses;
using Employee.Core.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Application.Handlers.CommandHandlers
{
    public class CreateEmployeeHandler
    {
        private readonly IEmployeeRepository _repository;

        public CreateEmployeeHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntitiy = EmployeeMapper.Mapper.Map<Employee.Core.Entities.Employee>(request);
            if (employeeEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newEmployee = await _repository.AddAsync(employeeEntitiy);
            var employeeResponse = EmployeeMapper.Mapper.Map<EmployeeResponse>(newEmployee);
            return employeeResponse;
        }
    }
}
