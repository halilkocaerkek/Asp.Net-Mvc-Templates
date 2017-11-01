using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataModel;
 
public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _entities;

    protected Repository(ddsport context)
    {
        _entities = context.Set<TEntity>();
    }

	public bool isExists ( int id )
	{
		return Find(id) != null;
	}

    public IEnumerable<TEntity> GetAll()
    {
        return _entities.ToList();
    }

    public TEntity Find(int id)
    {
        return _entities.Find(id);
    }

	public TEntity Find(string id)
    {
        return _entities.Find( id);
    }

	public TEntity Find(int? id)
    {
        return _entities.Find(id.Value);
    }

    public virtual void Add(TEntity entity)
    {
        _entities.Add(entity); 
    }

    public void Remove(TEntity entity)
    {
        _entities.Remove(entity);
    }
}

