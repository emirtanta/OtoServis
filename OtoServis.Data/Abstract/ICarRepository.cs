using OtoServis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Data.Abstract
{
    public interface ICarRepository:IRepository<Arac>
    {
        /// <summary>
        /// araç listesini getirir
        /// </summary>
        /// <returns></returns>
        Task<List<Arac>> GetCustomCarList();

        /// <summary>
        /// araç listesini belirli bir koşula göre getirir
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<List<Arac>> GetCustomCarList(Expression<Func<Arac,bool>> expression);

        /// <summary>
        /// id değerine göre hedef aracı getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Arac> GetCustomCar(int id);
    }
}
