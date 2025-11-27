using MediatR;
using Payroll.Domain.Entities;
using Shared;

namespace Payroll.Application.Handlers.Queries.GetPayslipByEmployeeCode;

public record GetPayslipByEmployeeCodeQuery(string employeeCode, int year, int month) : IRequest<Result<Payslip>>;
