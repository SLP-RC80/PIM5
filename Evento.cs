using System;
using System.Collections.Generic;

namespace PIMEventosTI.Models
{
    public class Evento
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }

        public List<Atividade> Atividades { get; private set; }

        public Evento(int id, string nome, DateTime inicio, DateTime fim)
        {
            Id = id;
            Nome = nome;
            DataInicio = inicio;
            DataFim = fim;
            Atividades = new List<Atividade>();
        }

        public void AdicionarAtividade(Atividade atividade)
        {
            Atividades.Add(atividade);
        }
    }
}
