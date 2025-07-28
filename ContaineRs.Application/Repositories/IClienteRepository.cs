using ContaineRs.Domain.Models;

namespace ContaineRs.Application.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> AddAsync(Cliente cliente);
    }
}
