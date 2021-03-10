using Commom.Dto;
using Data.Storage;
using Microsoft.EntityFrameworkCore;
using Service.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Storage
{
    public interface IBaseService
    {

    }

    public class Base<TEntity, TInterface> : IDisposable, IBaseService where TInterface : BaseDto where TEntity : class
    {
        internal DatabaseContext dbContext;
        public Base()
        {
            dbContext = new DatabaseContext();
        }


        public void Dispose()
        {
            dbContext.Dispose();
            dbContext = null;
        }

        public void Add(TInterface item)
        {
            try
            {
                var newitem = Mapping.Mapper.Map<TEntity>(item);
                dbContext.Attach(newitem);
                dbContext.Entry(newitem).State = EntityState.Added;
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Edit(TInterface item)
        {
            try
            {
                var inedit = Mapping.Mapper.Map<TEntity>(item);
                dbContext.Entry(inedit).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Guid Id)
        {
            DbSet<TEntity> dbSet = dbContext.Set<TEntity>();
            var indelete = dbSet.Find(Id);
            dbContext.Remove(indelete);
            dbContext.SaveChanges();
        }

        public virtual List<TInterface> GetAll()
        {
            try
            {
                DbSet<TEntity> dbSet = dbContext.Set<TEntity>();
                var list = dbSet.ToList<TEntity>();
                var convertedlist = new List<TInterface>();

                foreach (var item in list)
                {
                    convertedlist.Add(Mapping.Mapper.Map<TInterface>(item));
                }

                return convertedlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
