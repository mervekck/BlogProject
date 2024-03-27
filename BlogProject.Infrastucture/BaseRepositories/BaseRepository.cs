using BlogProject.Domain.Repository;
using BlogProject.Infrastucture.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Infrastucture.BaseRepositories
{
	public class BaseRepository<T> : IRepository<T> where T : class, new()
	{
		AppDbContext db;
        public BaseRepository(AppDbContext db)
        {
            this.db = db;
        }
		//Yeni bir öge eklemek için kullanılır.
		public void Add(T item)
		{
			try
			{
				db.Set<T>().Add(item);
				db.SaveChanges();
			}
			catch (Exception)
			{
				throw new Exception("Ekleme İşlemi Sırasında Hata Meydana Geldi");
			}
		}
		//Mevcut bir öğeyi düzenlemek için kullanılır.
		public void Edit(T item)
		{
			try
			{
				db.Set<T>().Update(item);
				db.SaveChanges();
			}
			catch (Exception)
			{
				throw new Exception("Güncelleme İşlemi Sırasında Hata Meydana Geldi");
			}
		}
		//Bir kimlik(ID) ile belirli bir öğeyi bulmak için kullanılır.
		public T Find(Guid id)
		{
			return db.Set<T>().Find(id);
		}
		//Tüm öğelerin bir listesini almak için kullanılır.
		public List<T> GetAll()
		{
			return db.Set<T>().ToList();
		}
		//Belirli bir koşula göre öğelerin bir alt kümesini almak için kullanılır.
		public List<T> GetBy(Func<T, bool> exp)
		{
			return db.Set<T>().Where(exp).ToList();
		}
		//Belirli bir koşula göre tek bir öğe almak için kullanılır.
		public T GetByEntity(Func<T, bool> exp)
		{
			return db.Set<T>().Where(exp).FirstOrDefault();
		}
		//Pasif durumdaki öğelerin bir listesini almak için kullanılır.
		public List<T> GetDeActive()
		{
			//PropertyInfo kullanılacak
			return null;
		}
		//Belirtilen bir öğeyi kaldırmak için kullanılır.
		public void Remove(T item)
		{
			try
			{
				db.Set<T>().Remove(item);
				db.SaveChanges();
			}
			catch (Exception)
			{
				throw new Exception("Silme İşlemi Sırasında Hata Meydana Geldi");
			}
		}
	}
}
