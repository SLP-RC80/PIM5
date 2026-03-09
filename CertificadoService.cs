using System.Collections.Generic;
using PIMEventosTI.Models;

namespace PIMEventosTI.Services
{
    public class CertificadoService
    {
        private List<Certificado> certificados = new List<Certificado>();
        private int nextId = 1;

        public Certificado GerarCertificado(Participante participante, Evento evento)
        {
            var certificado = new Certificado(nextId++, participante, evento);
            certificados.Add(certificado);
            return certificado;
        }

        public List<Certificado> ObterCertificados()
        {
            return certificados;
        }
    }
}
