using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (TransportationContext context = new TransportationContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (TransportationContext context = new TransportationContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(Brand entity)
        {
            using (TransportationContext context = new TransportationContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (TransportationContext context = new TransportationContext())
            {
                return filter == null
                    ? context.Set<Brand>().ToList()
                    : context.Set<Brand>().Where(filter).ToList();
            }
        }
        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (TransportationContext context = new TransportationContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }
    }
}
