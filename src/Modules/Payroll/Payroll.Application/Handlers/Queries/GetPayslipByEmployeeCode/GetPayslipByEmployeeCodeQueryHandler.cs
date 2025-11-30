using MediatR;
using Payroll.Application.Common.Interfaces;
using Payroll.Application.DTOs;
using Payroll.Domain.Interfaces;
using Shared;
using Shared.Conversions;
using Shared.Interfaces;

namespace Payroll.Application.Handlers.Queries.GetPayslipByEmployeeCode;

public class GetPayslipByEmployeeCodeQueryHandler : IRequestHandler<GetPayslipByEmployeeCodeQuery, Result<GetPayslipDto>>
{
    private readonly IPayslipRepository _payslipRepository;
    private readonly IEmployeeLookupService _employeeLookupService;

    public GetPayslipByEmployeeCodeQueryHandler(IPayslipRepository payslipRepository, IEmployeeLookupService employeeLookupService)
    {
        _payslipRepository = payslipRepository;
        _employeeLookupService = employeeLookupService;
    }

    public async Task<Result<GetPayslipDto>> Handle(GetPayslipByEmployeeCodeQuery request, CancellationToken cancellationToken)
    {
        var employeeCode = request.employeeCode.Trim();
        var year = request.year.ToString();
        var month = request.month.ToString();

        var result = new Result<GetPayslipDto>();

        var payslip = await _payslipRepository.GetPayslipByEmployeeCode(employeeCode, year.ToString(), month.ToString(), cancellationToken);

        if (payslip == null)
        {
            result.Status.Errors.Add($"Payslip for employee code {employeeCode} in {year}/{month} was not found");
            result.Status.IsPartialySuccess = false;
            return result;
        }

        var dto = new GetPayslipDto();
        Convertor.ProcessEntity2Dto(payslip, dto);

        var employeeName = await _employeeLookupService.GetEmployeeNameByIdAsync(payslip.EmployeeId, cancellationToken);

        dto.FirstName = employeeName.FirstName!;
        dto.LastName = employeeName.LastName!;

        result.Data.Data = dto;
        return result;
    }
}


