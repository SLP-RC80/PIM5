using System;

namespace PIMEventosTI.Models
{
    public class Atividade
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Tipo { get; private set; }
        public DateTime Horario { get; private set; }

        public Atividade(int id, string titulo, string tipo, DateTime horario)
        {
            Id = id;
            Titulo = titulo;
            Tipo = tipo;
            Horario = horario;
        }
    }
}
