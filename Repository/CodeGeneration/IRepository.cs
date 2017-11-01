using System.Collections.Generic;

public interface IRepository<T> where T : class
{
	bool isExists ( int id );
    IEnumerable<T> GetAll();
    T Find(int id);
	T Find(int? id);
	T Find(string id);
    void Add(T entity);
    void Remove(T entity);
}
