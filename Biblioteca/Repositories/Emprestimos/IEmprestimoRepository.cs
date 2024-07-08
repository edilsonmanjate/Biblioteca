﻿using Biblioteca.Models;

namespace Biblioteca.Repositories.Emprestimos
{
    public interface IEmprestimoRepository
    {
        Task<List<Emprestimo>> GetAllAsync();
        Task<Emprestimo?> GetByIdAsync(int id);
        Task AddAsync(Emprestimo agendamento);
        Task UpdateAsync(Emprestimo agendamento);
        Task DeleteAsync(int id);
        Task<List<Emprestimo>> GetReportAsync();
    }
}
