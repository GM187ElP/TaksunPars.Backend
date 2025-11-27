using MediatR;
using Payroll.Application.Common.Interfaces;
using Payroll.Domain.Interfaces;
using Shared;

namespace Payroll.Application.Handlers.Commands.UploadPayslipsFromExcel;

public class UploadPayslipsFromExcelCommandHandler : IRequestHandler<UploadPayslipsFromExcelCommand, ResultStatus>
{
    private readonly IPayslipRepository _repo;
    private readonly IExcelPayslipParser _parser;

    public UploadPayslipsFromExcelCommandHandler(IExcelPayslipParser parser, IPayslipRepository repo)
    {
        _parser = parser;
        _repo = repo;
    }

    public async Task<ResultStatus> Handle(UploadPayslipsFromExcelCommand request, CancellationToken cancellationToken)
    {
        var result = _parser.Parse(request.excelStream);

        if (result.Status.IsPartialySuccess)
            return await _repo.AddRangeAsync(result, cancellationToken);
        else
            return result.Status;
    }
}
