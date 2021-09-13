using Employee.Application.Queries;
using Employee.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Application.Handlers.QueryHandlers
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, List<Employee.Core.Entities.Employee>>
    {
        private readonly IEmployeeRepository _repository;

        public GetAllEmployeeHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Core.Entities.Employee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            return (List<Core.Entities.Employee>)await _repository.GetAllAsync();
        }
    }
}
