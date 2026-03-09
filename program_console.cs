using System;
using System.Collections.Generic;
using PIMEventosTI.Models;
using PIMEventosTI.Services;

namespace PIMEventosTI
{
    public class ProgramConsole
    {
        static EventoService eventoService = new EventoService();
        static InscricaoService inscricaoService = new InscricaoService();
        static CertificadoService certificadoService = new CertificadoService();

        static List<Participante> participantes = new List<Participante>();

        public static void RunConsole()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Sistema de Eventos Acadêmicos TI");
            Console.WriteLine("=================================");

            bool executando = true;

            while (executando)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1 - Cadastrar Evento");
                Console.WriteLine("2 - Listar Eventos");
                Console.WriteLine("3 - Cadastrar Participante");
                Console.WriteLine("4 - Realizar Inscrição");
                Console.WriteLine("5 - Listar Inscrições");
                Console.WriteLine("6 - Gerar Certificado");
                Console.WriteLine("0 - Sair");

                Console.Write("\nEscolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarEvento();
                        break;

                    case "2":
                        ListarEventos();
                        break;

                    case "3":
                        CadastrarParticipante();
                        break;

                    case "4":
                        RealizarInscricao();
                        break;

                    case "5":
                        ListarInscricoes();
                        break;

                    case "6":
                        GerarCertificado();
                        break;

                    case "0":
                        executando = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static void CadastrarEvento()
        {
            Console.Write("Nome do evento: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Data de início (dd/mm/aaaa): ");
            DateTime inicio = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString());

            Console.Write("Data de fim (dd/mm/aaaa): ");
            DateTime fim = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString());

            Evento evento = new Evento(eventoService.NextId(), nome, inicio, fim);
            eventoService.CriarEvento(evento);

            Console.WriteLine("Evento cadastrado com sucesso.");
        }

        static void ListarEventos()
        {
            Console.WriteLine("\nLista de Eventos:");
            var eventos = eventoService.ObterEventos();
            if (eventos.Count == 0)
            {
                Console.WriteLine("Nenhum evento cadastrado.");
                return;
            }
            foreach (var e in eventos)
            {
                Console.WriteLine($"{e.Id} - {e.Nome} ({e.DataInicio:dd/MM/yyyy} - {e.DataFim:dd/MM/yyyy})");
            }
        }

        static void CadastrarParticipante()
        {
            Console.Write("Nome do participante: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Instituição: ");
            string instituicao = Console.ReadLine() ?? "";

            Participante participante = new Participante(participantes.Count + 1, nome, email, instituicao);
            participantes.Add(participante);

            Console.WriteLine("Participante cadastrado.");
        }

        static void RealizarInscricao()
        {
            if (participantes.Count == 0)
            {
                Console.WriteLine("Nenhum participante cadastrado.");
                return;
            }

            Console.WriteLine("Escolha um participante:");
            for (int i = 0; i < participantes.Count; i++)
            {
                Console.WriteLine($"{i} - {participantes[i].Nome}");
            }

            int pIndex = int.Parse(Console.ReadLine() ?? "0");

            var eventos = eventoService.ObterEventos();
            if (eventos.Count == 0)
            {
                Console.WriteLine("Nenhum evento cadastrado.");
                return;
            }

            Console.WriteLine("Escolha um evento:");
            for (int i = 0; i < eventos.Count; i++)
            {
                Console.WriteLine($"{i} - {eventos[i].Nome}");
            }

            int eIndex = int.Parse(Console.ReadLine() ?? "0");

            inscricaoService.RegistrarInscricao(participantes[pIndex], eventos[eIndex]);
            Console.WriteLine("Inscrição realizada.");
        }

        static void ListarInscricoes()
        {
            Console.WriteLine("\nLista de Inscrições:");
            var inscricoes = inscricaoService.ObterInscricoes();
            if (inscricoes.Count == 0)
            {
                Console.WriteLine("Nenhuma inscrição realizada.");
                return;
            }
            foreach (var i in inscricoes)
            {
                Console.WriteLine($"{i.Participante.Nome} inscrito em {i.Evento.Nome}");
            }
        }

        static void GerarCertificado()
        {
            if (participantes.Count == 0)
            {
                Console.WriteLine("Nenhum participante cadastrado.");
                return;
            }

            Console.WriteLine("Escolha um participante:");
            for (int i = 0; i < participantes.Count; i++)
            {
                Console.WriteLine($"{i} - {participantes[i].Nome}");
            }

            int pIndex = int.Parse(Console.ReadLine() ?? "0");

            var eventos = eventoService.ObterEventos();
            Console.WriteLine("Escolha um evento:");
            for (int i = 0; i < eventos.Count; i++)
            {
                Console.WriteLine($"{i} - {eventos[i].Nome}");
            }

            int eIndex = int.Parse(Console.ReadLine() ?? "0");

            var cert = certificadoService.GerarCertificado(participantes[pIndex], eventos[eIndex]);
            Console.WriteLine($"Certificado gerado: ID {cert.Id}");
        }
    }
}
