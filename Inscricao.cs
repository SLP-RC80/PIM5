using System;

namespace PIMEventosTI.Models
{
    public class Inscricao
    {
        public int Id { get; private set; }
        public Participante Participante { get; private set; }
        public Evento Evento { get; private set; }
        public DateTime DataInscricao { get; private set; }

        public Inscricao(int id, Participante participante, Evento evento)
        {
            Id = id;
            Participante = participante;
            Evento = evento;
            DataInscricao = DateTime.Now;
        }
    }
}
