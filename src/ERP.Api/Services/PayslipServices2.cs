using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TaksunPars.Application.DTOs;

namespace TaksunPars.Api.Services;

public partial class PayslipServices
{
    public byte[] PayslipPdfGenerate(DownloadPayslipDto p)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var bytes = Document.Create(document =>
        {
            document.Page(page =>
            {
                page.Margin(20);
                page.Size(PageSizes.A4);

                // ---------------- HEADER ----------------
                page.Header().Border(1).Element(header =>
                {
                    header.Table(table =>
                    {
                        table.ColumnsDefinition(cols =>
                        {
                            cols.RelativeColumn();
                            cols.ConstantColumn(120);
                        });

                        table.Cell().Padding(5).AlignRight()
                            .Text($"نام و نام خانوادگی: {p.FullName}").Bold();

                        table.Cell().Padding(5)
                            .AlignCenter().Text(p.PersonnelCode).Bold().FontSize(16);

                        table.Cell().Padding(5).AlignRight()
                            .Text($"واحد سازمانی: {p.Department}");

                        table.Cell();
                    });
                });

                // ---------------- CONTENT ----------------
                page.Content().Border(1).Element(container =>
                {
                    container.Column(column =>
                    {
                        column.Spacing(10);

                        // Title
                        column.Item().AlignCenter()
                            .Text($"حقوق و مزایای ماه {p.Month} سال {p.Year}")
                            .FontSize(16).Bold();

                        // Main Table
                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.RelativeColumn();
                                cols.RelativeColumn();
                                cols.RelativeColumn();
                                cols.RelativeColumn();
                                cols.RelativeColumn();
                            });

                            // Add rows for left and right columns
                            AddTableRowWithBorders(table, "حقوق روزانه", p.DailySalary, "بیمه سهم کارگر", p.InsuranceWorkerShare);
                            AddTableRowWithBorders(table, "تعداد روز کاری", p.WorkingDays, "بیمه تکمیلی", p.SupplementaryInsurance);
                            AddTableRowWithBorders(table, "حقوق ثابت ماهانه", p.MonthlyBaseSalary, "مالیات حقوق", p.SalaryTax);
                            AddTableRowWithBorders(table, "بن کارگری", p.WorkerBenefit, "یک در هزار بیمه", p.OnePerThousandInsurance);
                            AddTableRowWithBorders(table, "حق مسکن", p.HousingAllowance, "وام شرکت (کسر شده)", p.CompanyLoanDeducted);
                            AddTableRowWithBorders(table, "حق اولاد", p.ChildAllowance, "وام شرکت (مانده)", p.CompanyLoanRemaining);
                            AddTableRowWithBorders(table, "حق ناهار", p.LunchAllowance, "جمع کسورات", p.TotalDeductions);
                            AddTableRowWithBorders(table, "حق ماموریت", p.MissionAllowance, "جمع حقوق و مزایا", p.TotalSalaryAndBenefits);
                            AddTableRowWithBorders(table, "موبایل", p.MissionAllowance, "ذخیره پورسانت", p.TotalSalaryAndBenefits);
                        });

                        // Footer Account Box
                        column.Item().PaddingTop(20).Border(1).Padding(10).Column(col =>
                        {
                            col.Item().AlignCenter().Text("شماره حساب").Bold().FontSize(14);
                            col.Item().AlignCenter().Text(p.AccountNumber).Bold().FontSize(16);
                        });
                    });
                });

                // ---------------- FOOTER ----------------
                page.Footer().Border(1).Element(footer =>
                {
                    footer.AlignCenter().Text(text =>
                    {
                        text.Span("صفحه ").FontSize(10);
                        text.CurrentPageNumber().FontSize(10);
                    });
                });
            });
        }).GeneratePdf();

        return bytes;
    }

    void AddTableRowWithBorders(TableDescriptor table, string rightLabel, object rightValue, string leftLabel, object leftValue)
    {
        table.Cell().Border(1).AlignCenter().Text(rightValue.ToString());
        table.Cell().Border(1).AlignRight().Text(rightLabel).Bold();
        table.Cell().Border(1).AlignRight().Text("");
        table.Cell().Border(1).AlignCenter().Text(leftValue.ToString());
        table.Cell().Border(1).AlignCenter().Text(leftLabel).Bold();
    }

}
