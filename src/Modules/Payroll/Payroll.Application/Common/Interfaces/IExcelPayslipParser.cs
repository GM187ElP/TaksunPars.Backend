using Payroll.Domain.Entities;
using Shared;


namespace Payroll.Application.Common.Interfaces;

public interface IExcelPayslipParser
{
    Result<List<Payslip>> Parse(Stream stream);
}