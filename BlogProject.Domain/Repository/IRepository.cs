using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Domain.Repository
{
	public interface IRepository<T> where T : class, new()
	{
		void Add(T item); //Yeni bir öge eklemek için kullanılır.
		void Edit(T item); //Mevcut bir öğeyi düzenlemek için kullanılır.
		void Remove(T item); //Belirtilen bir öğeyi kaldırmak için kullanılır.

		List<T> GetAll(); //Tüm öğelerin bir listesini almak için kullanılır.
		List<T> GetBy(Func<T,bool> exp); //Belirli bir koşula göre öğelerin bir alt kümesini almak için kullanılır.

		List<T> GetDeActive(); //Pasif durumdaki öğelerin bir listesini almak için kullanılır.
		T Find(Guid id); //Bir kimlik(ID) ile belirli bir öğeyi bulmak için kullanılır.
		T GetByEntity(Func<T,bool> exp); //Belirli bir koşula göre tek bir öğe almak için kullanılır.
	}
}
