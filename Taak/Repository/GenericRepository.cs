﻿using Taak.Data;
using Microsoft.EntityFrameworkCore;



namespace Taak.Repository
{
    //generic repository for CRUD operations
    public class GenericRepository<T, TModel> where T : class, new()
                                               where TModel : class, new()
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = db.Set<T>();
        }


        public static T MapModelToDBObject(TModel objSource, T objCopy)
        {
            var objSourceProperties = objSource.GetType().GetProperties();
            var objCopyProperties = objCopy.GetType().GetProperties();

            foreach (var objSourceProperty in objSourceProperties)
            {
                foreach (var objCopyProperty in objCopyProperties)
                {
                    if (objSourceProperty.Name == objCopyProperty.Name)
                    {
                        objCopyProperty.SetValue(objCopy, objSourceProperty.GetValue(objSource));
                        break;
                    }
                }
            }
            return objCopy;
        }
        public static TModel MapDBObjectToModel(T objSource, TModel objCopy)
        {
            var objSourceProperties = objSource.GetType().GetProperties();
            var objCopyProperties = objCopy.GetType().GetProperties();

            foreach (var objSourceProperty in objSourceProperties)
            {
                foreach (var objCopyProperty in objCopyProperties)
                {
                    if (objSourceProperty.Name == objCopyProperty.Name)
                    {
                        objCopyProperty.SetValue(objCopy, objSourceProperty.GetValue(objSource));
                        break;
                    }
                }
            }
            return objCopy;
        }

        public List<TModel> GetAll()
        {
            var list = new List<TModel>();
            
            foreach (var dbObject in dbSet)
            {
                list.Add(MapDBObjectToModel(dbObject, new TModel()));
            }
            return list;
        }
        public void Insert(TModel model)
        {

            dbSet.Add(MapModelToDBObject(model, new T()));
            _db.SaveChanges();
        }

        public TModel GetById(Guid id)
        {
            
            return MapDBObjectToModel(dbSet.Find(id), new TModel());
        }

        public void Delete(Guid id)
        {
            var dbObject = dbSet.Find(id);
            if (dbObject != null)
            {
                _db.Remove(dbObject);
                _db.SaveChanges();
            }
        }
        public void Update(TModel model, Guid id)
        {
            var dbObject = dbSet.Find(id);
            if (dbObject != null)
            {
                MapModelToDBObject(model, dbObject);

                _db.SaveChanges();
            }
        }


    }
}
