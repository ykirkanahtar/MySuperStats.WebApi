//https://github.com/Arch/UnitOfWork/blob/master/src/Microsoft.EntityFrameworkCore.UnitOfWork/IUnitOfWork.cs


using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BasketballStats.WebApi.Data.Contracts
{
    /// <summary>
    /// Defines the interface(s) for generic unit of work.
    /// </summary>
    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        /// <summary>
        /// Gets the db context.
        /// </summary>
        /// <returns>The instance of type <typeparamref name="TContext"/>.</returns>
        TContext DbContext { get; }

        /// <summary>
        /// Saves all changes made in this context to the database with distributed transaction.
        /// </summary>
        /// <param name="unitOfWorks">An optional <see cref="IUnitOfWork"/> array.</param>
        /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous save operation. The task result contains the number of state entities written to database.</returns>
        Task<int> SaveChangesAsync(params IUnitOfWork[] unitOfWorks);
    }
}
