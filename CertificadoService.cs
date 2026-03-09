using System;
using System.IO;

public class CertificadoService
{
    public void GerarCertificado(Usuario usuario, Evento evento)
    {
        try
        {
            string nomeArquivo = $"certificado_{usuario.Nome}.txt";

            string conteudo = $"Certificado de Participação\n\n" +
                              $"Participante: {usuario.Nome}\n" +
                              $"Evento: {evento.Titulo}\n" +
                              $"Data: {evento.Data}\n\n" +
                              $"A organização certifica a participação no evento.";

            File.WriteAllText(nomeArquivo, conteudo);

            Console.WriteLine("Certificado gerado: " + nomeArquivo);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao gerar certificado: " + ex.Message);
        }
    }
}
