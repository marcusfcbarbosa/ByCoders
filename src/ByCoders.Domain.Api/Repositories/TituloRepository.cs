using ByCoders.Core.Data;
using ByCoders.Core.Extensions;
using ByCoders.Core.Interfaces;
using ByCoders.Domain.Api.Data;
using ByCoders.Domain.Api.Entities;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByCoders.Domain.Api.Repositories
{
    public interface ITituloRepository : IRepository<Titulo>
    {
        Task<PagedResult<Titulo>> GetAllTitulosPaged(int pageSize, int pageIndex, string query = null);
    }
    public class TituloRepository : ITituloRepository
    {
        private readonly ByCodersDBContext _context;
        public TituloRepository(ByCodersDBContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void Add(Titulo entity)
        {
            _context.Titulos.Add(entity);
        }

        public Task DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<IEnumerable<Titulo>> GetAll()
        {
            return await _context.Titulos.AsNoTracking().ToListAsync();
        }

        public async Task<PagedResult<Titulo>> GetAllTitulosPaged(int pageSize, int pageIndex, string query = null)
        {
            var sql = @$"SELECT * FROM Cars 
                      WHERE (@Nome IS NULL OR Model LIKE '%' + @Nome + '%') 
                      ORDER BY [Model] 
                      OFFSET {pageSize * (pageIndex - 1)} ROWS 
                      FETCH NEXT {pageSize} ROWS ONLY 
                      SELECT COUNT(Id) FROM Cars 
                      WHERE (@Nome IS NULL OR Model LIKE '%' + @Nome + '%')";

            var multi = await _context.Database.GetDbConnection()
                .QueryMultipleAsync(sql, new { Nome = query });

            var cars = multi.Read<Titulo>();
            var total = multi.Read<int>().FirstOrDefault();

            return new PagedResult<Titulo>()
            {
                List = cars,
                TotalResults = total,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query
            };
        }

        public Task<Titulo> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Titulo entity)
        {
            throw new NotImplementedException();
        }
    }
}
