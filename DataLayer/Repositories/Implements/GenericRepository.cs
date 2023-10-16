using DataLayer.DBContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly TestContext testContext;

        public GenericRepository(TestContext testContext)
        {
            this.testContext = testContext;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

            testContext.Set<TEntity>().Remove(entity);
            await testContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await testContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await testContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            testContext.Set<TEntity>().Add(entity);
            await testContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            //testContext.Entry(entity).State = EntityState.Modified;
            testContext.Set<TEntity>().AddOrUpdate(entity);
            await testContext.SaveChangesAsync();
            return entity;
        }
    }
}
