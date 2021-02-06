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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (TransportationContext context = new TransportationContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (TransportationContext context = new TransportationContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(Color entity)
        {
            using (TransportationContext context = new TransportationContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (TransportationContext context = new TransportationContext())
            {
                return filter == null
                    ? context.Set<Color>().ToList()
                    : context.Set<Color>().Where(filter).ToList();
            }
        }
        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (TransportationContext context = new TransportationContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }
    }
}
