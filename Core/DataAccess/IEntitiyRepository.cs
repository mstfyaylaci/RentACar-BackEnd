using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // Generic repository Fonksiyonları
                                                //Generic Constrait
    public interface IEntitiyRepository<T> where T : class, IEntity, new() // where :class = referans tip olması gerekmekte
                                                                           // IEntity: İmplemente olunmuş veri tabanı nesnesi
                                                                           // new(): newlenebilir olması yani class olması gerekmekte
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null ); //Expression func: Linq yazılabilmesi için gerekli
                                                               //filtre varsa uygula yoksa ürünleri getir
                                                               //örnek:p=>p.id==id

        T Get(Expression<Func<T, bool>> filter);// filtre zorunlu
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        
    }
}
