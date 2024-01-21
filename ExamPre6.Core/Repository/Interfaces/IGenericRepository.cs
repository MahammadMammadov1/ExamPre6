using ExamPre6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre6.Core.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task CreateAsync(TEntity entity);
        public DbSet<TEntity> Table {  get; }
        Task<int> CommitAsync();
        void DeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity , bool>>? expression = null , params string[] includes);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity , bool>>? expression = null , params string[] includes);
    }
}
