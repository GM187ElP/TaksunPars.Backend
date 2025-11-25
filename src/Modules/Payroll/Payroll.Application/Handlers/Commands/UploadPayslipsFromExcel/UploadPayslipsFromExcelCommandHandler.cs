using MediatR;
using Payroll.Application.Common.Interfaces;
using Payroll.Domain.Interfaces;

namespace Payroll.Application.Handlers.Commands.UploadPayslipsFromExcel;

public class UploadPayslipsFromExcelCommandHandler : IRequestHandler<UploadPayslipsFromExcelCommand,int>
{
    private readonly IPayslipRepository _repo;
    private readonly IExcelPayslipParser _parser;

    public UploadPayslipsFromExcelCommandHandler(IExcelPayslipParser parser, IPayslipRepository repo)
    {
        _parser = parser;
        _repo = repo;
    }

    public async Task<int> Handle(UploadPayslipsFromExcelCommand request, CancellationToken cancellationToken)
    {
        var result = _parser.Parse(request.excelStream);
        if(result.IsPartialySuccess)
        await _repo.AddRangeAsync(payslips, cancellationToken);
        return 2;
    }
}
