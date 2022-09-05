using Project.ENTITES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesingPatterns.GenericRepository.InRepo
{
    public interface IRepository<T> where T : BaseEntity
    {


        //List Command

        List<T> GetAll();

        List<T> GetActives();

        List<T> GetUpdates();

        List<T> GetDeleted();

        //Modify Command

        void Add(T item);

        void AddRange(List<T> list);

        void Delete(T item);

        void DeleteRange(List<T> list);

        void Update(T item);

        void UpdateRange(List<T> list);

        void Destroy(T item);

        void DestroyRange(List<T> list);

        void SetActives(T item);

        void SetActivesRange(List<T> list);


        //Linq Command

        T FirsOrDefault(Expression<Func<T, bool>> exp);

        bool Any(Expression<Func<T,bool>> exp);

        object Select(Expression<Func<T, object>> exp);


        List<T> Where(Expression<Func<T, bool>>exp);


        //Find

        T Find(int id);

        //Get First Datas

        List<T> GetFirstDatas(int number);

        //Get Last Datas

        List<T> GetLastDatas(int number);

        //Get Datas 

        List<T> GetDatas(int number);








    }
}
