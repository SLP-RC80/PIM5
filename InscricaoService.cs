using System;
using System.Collections.Generic;
using System.Linq;

public class InscricaoService
{
    private List<Inscricao> inscricoes = new List<Inscricao>();

    public void RegistrarInscricao(Usuario usuario, Evento evento)
    {
        Inscricao nova = new Inscricao(usuario, evento);
        inscricoes.Add(nova);

        Console.WriteLine("Inscrição realizada com sucesso!");
    }

    public void ListarInscricoes()
    {
        Console.WriteLine("\nLista de Inscrições:");

        foreach (var i in inscricoes)
        {
            Console.WriteLine($"{i.Usuario.Nome} inscrito em {i.Evento.Titulo}");
        }
    }

    public List<Inscricao> BuscarPorEvento(string tituloEvento)
    {
        return inscricoes
            .Where(i => i.Evento.Titulo == tituloEvento)
            .ToList();
    }
}
