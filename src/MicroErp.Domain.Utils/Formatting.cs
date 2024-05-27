using System.Text.RegularExpressions;

namespace MicroErp.Domain.Utils;

public static class Formatting
{
    public static string RemoverCaracteresEspeciaisCNPJ(string texto)
    {
        // Remove os caracteres ".", "/", e "-"
        string textoSemPontuacao = texto.Replace(".", "").Replace("/", "").Replace("-", "");
        return textoSemPontuacao;
    }
    public static string FormatarTelefone(string telefone)
    {
        // Remover parênteses, hífen e espaços em branco
        string telefoneSemFormatacao = Regex.Replace(telefone, @"[\(\)\- ]", "");

        return telefoneSemFormatacao;
    }
    public static string RemoverPontosIE(string entrada)
    {
        // Substitui os pontos e espaços vazios por uma string vazia
        return entrada.Replace(".", "").Replace(" ", "");
    }

    public static string FormatCNPJ(string cnpj)
    {
        return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
    }
    
    public static string FormatCPF(string cpf)
    {
        return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
    }
}
