using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.Relatorio;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace MicroErp.Domain.Service.Concretes.OrdemServico;

public partial class OrdemServicoService
{
    public async Task<ResponseDto<RelatorioExcelResponseDto>> RelatorioExcelAsync(RelatorioExcelRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(RelatorioExcelAsync));
        try
        {
            var list = await _repositoryOrdemServico.Query
                .Include(o => o.DetalhesOrdemServico)
                .Include(o => o.Cliente)
                .ToListAsync();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("OrdemServicos");
            workSheet.TabColor = System.Drawing.Color.Black;
            
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;
            
            #region Header
            workSheet.Cells[1, 1].Value = "Cliente";
            workSheet.Cells[1, 2].Value = "Nota Fiscal";
            workSheet.Cells[1, 3].Value = "Pedido";
            workSheet.Cells[1, 4].Value = "Descricao";
            workSheet.Cells[1, 5].Value = "Orcamento";
            workSheet.Cells[1, 6].Value = "Quantidade";
            workSheet.Cells[1, 7].Value = "Unidade";
            workSheet.Cells[1, 8].Value = "Valor Unitario";
            workSheet.Cells[1, 9].Value = "Valor Total";
            workSheet.Cells[1, 10].Value = "Data Emissao";
            workSheet.Cells[1, 11].Value = "Prazo";
            workSheet.Cells[1, 12].Value = "Data Entrega";
            workSheet.Cells[1, 13].Value = "Numero OS";
            workSheet.Cells[1, 14].Value = "Entregue Em";
            #endregion

            int indice = 2;

            foreach (var itn in list.OrderByDescending(o => o.NumeroOS))
            {
                var detalhes = itn.DetalhesOrdemServico.Select(d => 
                    new { d.Descricao, d.Quantidade, d.Unidade, d.ValorUnitario }
                );
                var cliente = itn.Cliente;

                if (detalhes.Count() == 1)
                {
                    workSheet.Cells[indice, 1].Value = cliente.Nome;
                    workSheet.Cells[indice, 2].Value = string.IsNullOrEmpty(itn.NotaSaida) ? string.Empty : itn.NotaSaida;
                    workSheet.Cells[indice, 3].Value = string.IsNullOrEmpty(itn.Pedido) ? string.Empty : itn.Pedido;
                    workSheet.Cells[indice, 4].Value = detalhes.FirstOrDefault().Descricao;
                    workSheet.Cells[indice, 5].Value = string.IsNullOrEmpty(itn.Orcamento) ? string.Empty : itn.Orcamento;
                    workSheet.Cells[indice, 6].Value = detalhes.FirstOrDefault().Quantidade;
                    workSheet.Cells[indice, 7].Value = detalhes.FirstOrDefault().Unidade;
                    workSheet.Cells[indice, 8].Value = detalhes.FirstOrDefault().ValorUnitario;;
                    workSheet.Cells[indice, 9].Value = itn.ValorTotal.ToString();
                    workSheet.Cells[indice, 10].Value = string.IsNullOrEmpty(itn.DataCadastro.ToString()) ? string.Empty : itn.DataCadastro.Value.ToShortDateString();
                    workSheet.Cells[indice, 11].Value = string.IsNullOrEmpty(itn.Prazo.ToString()) ? string.Empty : itn.Prazo;
                    workSheet.Cells[indice, 12].Value = string.IsNullOrEmpty(itn.DataPrevisaoEntrega.ToString()) ? string.Empty : itn.DataPrevisaoEntrega.Value.ToShortDateString();
                    workSheet.Cells[indice, 13].Value = itn.NumeroOS;
                    workSheet.Cells[indice, 14].Value = string.IsNullOrEmpty(itn.DataEntrega.ToString()) ? string.Empty : itn.DataEntrega.Value.ToLongDateString();
                    indice++;
                }
                else
                {
                    var index = detalhes.Count();

                    foreach (var detalhe in detalhes)
                    {
                        workSheet.Cells[indice, 1].Value = cliente.Nome;
                        workSheet.Cells[indice, 2].Value = string.IsNullOrEmpty(itn.NotaSaida) ? string.Empty : itn.NotaSaida;
                        workSheet.Cells[indice, 3].Value = string.IsNullOrEmpty(itn.Pedido) ? string.Empty : itn.Pedido;
                        workSheet.Cells[indice, 4].Value = detalhe.Descricao;
                        workSheet.Cells[indice, 5].Value = string.IsNullOrEmpty(itn.Orcamento) ? string.Empty : itn.Orcamento;
                        workSheet.Cells[indice, 6].Value = detalhe.Quantidade;
                        workSheet.Cells[indice, 7].Value = detalhe.Unidade;;
                        workSheet.Cells[indice, 8].Value = detalhe.ValorUnitario;
                        workSheet.Cells[indice, 9].Value = itn.ValorTotal;
                        workSheet.Cells[indice, 10].Value = string.IsNullOrEmpty(itn.DataCadastro.ToString()) ? string.Empty : itn.DataCadastro.Value.ToShortDateString();
                        workSheet.Cells[indice, 11].Value = string.IsNullOrEmpty(itn.Prazo.ToString()) ? string.Empty : itn.Prazo;
                        workSheet.Cells[indice, 12].Value = string.IsNullOrEmpty(itn.DataPrevisaoEntrega.ToString()) ? string.Empty : itn.DataPrevisaoEntrega.Value.ToShortDateString();
                        workSheet.Cells[indice, 13].Value = itn.NumeroOS;
                        workSheet.Cells[indice, 14].Value = string.IsNullOrEmpty(itn.DataEntrega.ToString()) ? string.Empty : itn.DataEntrega.Value.ToShortDateString();
                        indice++;
                    }
                }
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();
            
            var result = new RelatorioExcelResponseDto
            {
                Dados = Convert.ToBase64String(excel.GetAsByteArray())
            };
            
            excel.Dispose();
            return ResponseDto<RelatorioExcelResponseDto>.Sucess(result);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback(cancellationToken);
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<RelatorioExcelResponseDto>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(RelatorioExcelAsync));
        }
    }
}