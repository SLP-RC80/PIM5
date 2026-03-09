using System;

namespace PIMEventosTI.Models
{
    public class Certificado
    {
        public int Id { get; private set; }
        public Participante Participante { get; private set; }
        public Evento Evento { get; private set; }
        public DateTime DataEmissao { get; private set; }

        public Certificado(int id, Participante participante, Evento evento)
        {
            Id = id;
            Participante = participante;
            Evento = evento;
            DataEmissao = DateTime.Now;
        }
    }
}
