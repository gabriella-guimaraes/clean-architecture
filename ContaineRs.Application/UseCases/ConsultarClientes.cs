﻿using ContaineRs.Application.Repositories;
using ContaineRs.Domain.Models;

namespace ContaineRs.Application.UseCases
{
    public class ConsultarClientes
    {
        private readonly IClienteRepository repository;

        public ConsultarClientes(UnidadeFederativa? estado, IClienteRepository repository)
        {
            Estado = estado;
            this.repository = repository;
        }

        public UnidadeFederativa? Estado { get; }

        public Task<IEnumerable<Cliente>> ExecutarAsync()
        {
            if (Estado is not null)
            {
                return repository.GetAsync(c => c.Estado == Estado);
            }

            return repository.GetAsync();
        }
    }
}
