using System.Net;
using ClosedXML.Excel;
using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.PrintOrdem;

namespace MicroErp.Application.OrdemProducaoCases.PrintOrdem;

public class PrintOrdemProducaoHandler: IRequestHandler<PrintOrdemProducaoRequest, ResponseDto<PrintOrdemProducaoResponseDto>>
{
    public PrintOrdemProducaoHandler()
    {
        
    }

    public async Task<ResponseDto<PrintOrdemProducaoResponseDto>> Handle(PrintOrdemProducaoRequest request, CancellationToken cancellationToken)
    {
        var response = new PrintOrdemProducaoResponseDto();
        using (var stream = new MemoryStream())
        {
            request.Arquivo.CopyTo(stream);
            stream.Position = 0;

            using (var workbook = new XLWorkbook(stream))
            {
                string worksheetName = "FORM007";
                if (workbook.Worksheets.TryGetWorksheet(worksheetName, out IXLWorksheet worksheet))
                {
                    worksheet.Cell("L1").Value = DateTime.Now.ToString("dd/MM/yyyy");
                    worksheet.Cell("T1").Value = "10";
                    worksheet.Cell("C2").Value = "Luis";
                    worksheet.Cell("I2").Value = "Teste de Produto";
                    worksheet.Cell("Q2").Value = "50";

                }

                using (var outputStream = new MemoryStream())
                {
                    workbook.SaveAs(outputStream);
                    outputStream.Position = 0;
                    response.File = Convert.ToBase64String(stream.ToArray());
                    response.Content = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    response.NomeFile = $"FORM007 - Ordem de Produção_10.xls";
                }
            }
        }
        return ResponseDto<PrintOrdemProducaoResponseDto>.Sucess(response);
    }
}