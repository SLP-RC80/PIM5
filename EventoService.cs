using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class EventoService
{
    private List<Evento> eventos = new List<Evento>();

    public void CriarEvento(Evento evento)
    {
        eventos.Add(evento);
        Console.WriteLine("Evento criado com sucesso!");
    }

    public void ListarEventos()
    {
        Console.WriteLine("\nLista de Eventos:");

        foreach (var evento in eventos)
        {
            Console.WriteLine($"{evento.Titulo} - {evento.Data} - {evento.Local}");
        }
    }

    public Evento BuscarEvento(string titulo)
    {
        return eventos.FirstOrDefault(e => e.Titulo == titulo);
    }

    public void SalvarEventos()
    {
        try
        {
            File.WriteAllLines("eventos.txt",
                eventos.Select(e => $"{e.Titulo};{e.Descricao};{e.Data};{e.Local}"));

            Console.WriteLine("Eventos salvos em arquivo.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao salvar eventos: " + ex.Message);
        }
    }
}
