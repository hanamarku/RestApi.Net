﻿using ClassLibraryModels;
using System.Linq.Expressions;

namespace restApiProject.Data.BaseRepository
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(int id, T entity);

        Task<ServiceResponse<string>> DeleteAsync(int id);
    }
}
