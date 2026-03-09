using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PIMEventosTI.Data
{
    public class ArquivoPersistencia<T>
    {
        private string caminhoArquivo;

        public ArquivoPersistencia(string caminho)
        {
            caminhoArquivo = caminho;
        }

        public void Salvar(List<T> dados)
        {
            try
            {
                string json = JsonSerializer.Serialize(dados);
                File.WriteAllText(caminhoArquivo, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar arquivo: " + ex.Message);
            }
        }

        public List<T> Carregar()
        {
            try
            {
                if (!File.Exists(caminhoArquivo))
                    return new List<T>();

                string json = File.ReadAllText(caminhoArquivo);
                return JsonSerializer.Deserialize<List<T>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao ler arquivo: " + ex.Message);
                return new List<T>();
            }
        }
    }
}
