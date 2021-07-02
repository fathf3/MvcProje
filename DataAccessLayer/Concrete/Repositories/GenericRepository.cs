﻿using DataAccessLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    // Sart : T degeri class olmalı
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        Context context = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            // Disaridan gelen entity ne ise _object o olacak
            _object = context.Set<T>();

        }

        public void Delete(T p)
        {
            var deletedEntity = context.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
        // Dosya aramak için kullanılır
        public T Get(Expression<Func<T, bool>> filter)
        {
            // ID = 5 olan tek deger doner
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            var addedEntity = context.Entry(p);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedEntity = context.Entry(p);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
