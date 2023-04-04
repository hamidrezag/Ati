using Domain.Dtos;
using Domain.Entities;
using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repo
{
    public interface IBaseRepo<T> where T : class, IBaseModel, new()
    {
        Task<T> GetOneAsync(int id, CancellationToken cancellationToken);
        Task InsertAsync(T item, CancellationToken cancellationToken);
        Task UpdateAsync(List<Expression<Func<T, object>>> props, T model, long id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task<List<T>> GetAllWithFilterAsync(int pageSize, int pageNumber, bool ascSorted, Expression<Func<T, dynamic>> orderField = null, Expression<Func<T, bool>> filter = null, CancellationToken cancellationToken = default);
        Task<List<T>> GetAllWithFilterAsync(int pageSize, int pageNumber, bool ascSorted, string orderField, Expression<Func<T, bool>> filter = null, CancellationToken cancellationToken = default);
        Task<int> GetCountWithFilterAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
    }
}
