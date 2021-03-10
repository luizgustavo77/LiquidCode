using Commom.Dto;
using Data.Core;
using Microsoft.EntityFrameworkCore;
using Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Core
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

        public virtual RetornaAcaoDto Add(TInterface item)
        {
            RetornaAcaoDto retorna = new RetornaAcaoDto();
            try
            {
                var newitem = Mapping.Mapper.Map<TEntity>(item);
                dbContext.Attach(newitem);
                dbContext.Entry(newitem).State = EntityState.Added;
                dbContext.SaveChanges();

                retorna.Retorno = true;
            }
            catch (Exception ex)
            {
                retorna.Mensagem = ex.Message;
                throw ex;
            }

            return retorna;
        }

        public virtual RetornaAcaoDto Edit(TInterface item)
        {
            RetornaAcaoDto retorna = new RetornaAcaoDto();
            try
            {
                var inedit = Mapping.Mapper.Map<TEntity>(item);
                dbContext.Entry(inedit).State = EntityState.Modified;
                dbContext.SaveChanges();
                retorna.Retorno = true;
            }
            catch (Exception ex)
            {
                retorna.Mensagem = ex.Message;
                throw ex;
            }

            return retorna;
        }

        public virtual RetornaAcaoDto Delete(Guid Id)
        {
            RetornaAcaoDto retorna = new RetornaAcaoDto();

            try
            {
                DbSet<TEntity> dbSet = dbContext.Set<TEntity>();
                var indelete = dbSet.Find(Id);
                dbContext.Remove(indelete);
                dbContext.SaveChanges();
                retorna.Retorno = true;
            }
            catch (Exception ex)
            {
                retorna.Mensagem = ex.Message;
            }

            return retorna;
        }

        public virtual TInterface Find(Guid Id)
        {
            DbSet<TEntity> dbSet = dbContext.Set<TEntity>();
            var item = dbSet.Find(Id);
            return Mapping.Mapper.Map<TInterface>(item);
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
