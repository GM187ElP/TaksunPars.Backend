using MediatR;
using Shared;

namespace Payroll.Application.Handlers.Commands.UploadPayslipsFromExcel;

public record UploadPayslipsFromExcelCommand(Stream excelStream) : IRequest<ResultStatus>;
