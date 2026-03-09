using System.Collections.Generic;
using System.Linq;
using PIMEventosTI.Models;

namespace PIMEventosTI.Services
{
    public class InscricaoService
    {
        private List<Inscricao> inscricoes = new List<Inscricao>();
        private int nextId = 1;

        public void RegistrarInscricao(Participante participante, Evento evento)
        {
            Inscricao nova = new Inscricao(nextId++, participante, evento);
            inscricoes.Add(nova);
        }

        public List<Inscricao> ObterInscricoes()
        {
            return inscricoes;
        }

        public List<Inscricao> BuscarPorEvento(int eventoId)
        {
            return inscricoes.Where(i => i.Evento.Id == eventoId).ToList();
        }
    }
}
