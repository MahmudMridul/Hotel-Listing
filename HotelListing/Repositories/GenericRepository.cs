using HotelListing.IRepositories;
using HotelListing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelListing.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelListingContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(HotelListingContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task<IList<T>> GetAll( Expression<Func<T, bool>> expression = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                List<string> includes = null
            )

        {
            IQueryable<T> query = _db;

            /* Include is for addtional details. For instance 
             instead of getting an entity and then chekcing its
            foreign key to get another data, with the help of
            include we can get all data at once*/

            if(expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var IncludeProperty in includes)
                {
                    query = query.Include(IncludeProperty);
                }
            }

            if(orderBy != null)
            {
                query = orderBy(query);
            }

            /* Expression is lambda expression. Through this
             * we can get an entity by id, name or anything
             which gives us more flexibility */

            /* Here in Get function, the database is not keeping track of
             * the data it is sending to the user. It just sends a copy
             of the data. That's why AsNoTracking fucntion has been used */
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression = null, 
            List<string> includes = null)
        {
            IQueryable<T> query = _db;

            /* Include is for addtional details. For instance 
             instead of getting an entity and then chekcing its
            foreign key to get another data, with the help of
            include we can get all data at once*/

            if(includes != null)
            {
                foreach(var IncludeProperty in includes)
                {
                    query = query.Include(IncludeProperty);
                }
            }
            /* Expression is lambda expression. Through this
             * we can get an entity by id, name or anything
             which gives us more flexibility */

            /* Here in Get function, the database is not keeping track of
             * the data it is sending to the user. It just sends a copy
             of the data. That's why AsNoTracking fucntion has been used */
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            if(entity != null)
            {
                _db.Remove(entity);
            }
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }



    }
}
