using System.Collections.Generic;
using PIMEventosTI.Models;

namespace PIMEventosTI.Services
{
    public class EventoService
    {
        private List<Evento> eventos = new List<Evento>();
        private int nextId = 1;

        public void CriarEvento(Evento evento)
        {
            eventos.Add(evento);
        }

        public List<Evento> ObterEventos()
        {
            return eventos;
        }

        public Evento? BuscarEvento(int id)
        {
            return eventos.Find(e => e.Id == id);
        }

        public int NextId() => nextId++;
    }
}
