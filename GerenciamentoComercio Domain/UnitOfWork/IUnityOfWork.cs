using System;

namespace GerenciamentoComercio_Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
