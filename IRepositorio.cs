using System.Collections.Generic;

namespace PIMEventosTI.Interfaces
{
    public interface IRepositorio<T>
    {
        void Adicionar(T item);
        List<T> Listar();
    }
}
