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
                        eventoService.ListarEventos();
                        break;

                    case "3":
                        CadastrarParticipante();
                        break;

                    case "4":
                        RealizarInscricao();
                        break;

                    case "5":
                        inscricaoService.ListarInscricoes();
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
            Console.Write("Título do evento: ");
            string titulo = Console.ReadLine();

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Local: ");
            string local = Console.ReadLine();

            Console.Write("Data (dd/mm/aaaa): ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            Evento evento = new Evento(titulo, descricao, data, local);

            eventoService.CriarEvento(evento);

            Console.WriteLine("Evento cadastrado com sucesso.");
        }

        static void CadastrarParticipante()
        {
            Console.Write("Nome do participante: ");
            string nome = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Participante participante = new Participante(nome, email);

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

            int pIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Escolha um evento:");
            var eventos = eventoService.ObterEventos();

            for (int i = 0; i < eventos.Count; i++)
            {
                Console.WriteLine($"{i} - {eventos[i].Titulo}");
            }

            int eIndex = int.Parse(Console.ReadLine());

            inscricaoService.RegistrarInscricao(participantes[pIndex], eventos[eIndex]);

            Console.WriteLine("Inscrição realizada.");
        }

        static void GerarCertificado()
        {
            Console.WriteLine("Escolha um participante:");

            for (int i = 0; i < participantes.Count; i++)
            {
                Console.WriteLine($"{i} - {participantes[i].Nome}");
            }

            int pIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Escolha um evento:");

            var eventos = eventoService.ObterEventos();

            for (int i = 0; i < eventos.Count; i++)
            {
                Console.WriteLine($"{i} - {eventos[i].Titulo}");
            }

            int eIndex = int.Parse(Console.ReadLine());

            certificadoService.GerarCertificado(participantes[pIndex], eventos[eIndex]);
        }
    }
}
