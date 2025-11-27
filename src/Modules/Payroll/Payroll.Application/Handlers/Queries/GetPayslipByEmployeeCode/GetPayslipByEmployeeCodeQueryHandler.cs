using MediatR;
using Payroll.Domain.Entities;
using Payroll.Domain.Interfaces;
using Shared;

namespace Payroll.Application.Handlers.Queries.GetPayslipByEmployeeCode;

public class GetPayslipByEmployeeCodeQueryHandler : IRequestHandler<GetPayslipByEmployeeCodeQuery, Result<Payslip>>
{
    private readonly IPayslipRepository _payslipRepository;

    public GetPayslipByEmployeeCodeQueryHandler(IPayslipRepository payslipRepository)
    {
        _payslipRepository = payslipRepository;
    }

    public async Task<Result<Payslip>> Handle(GetPayslipByEmployeeCodeQuery request, CancellationToken cancellationToken)
    {
        return await _payslipRepository.GetPayslipByEmployeeCode(request.employeeCode, request.year, request.month, cancellationToken);
    }
}
