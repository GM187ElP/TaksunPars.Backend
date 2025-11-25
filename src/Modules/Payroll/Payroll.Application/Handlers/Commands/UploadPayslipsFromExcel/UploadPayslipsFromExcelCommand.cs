using MediatR;

namespace Payroll.Application.Handlers.Commands.UploadPayslipsFromExcel;

public record UploadPayslipsFromExcelCommand(Stream excelStream) : IRequest<Result>;
