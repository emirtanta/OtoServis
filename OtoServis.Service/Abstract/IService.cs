using OtoServis.Data.Abstract;
using OtoServis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Service.Abstract
{
    public interface IService<T>:IRepository<T> where T : class,IEntity,new()
    {
    }
}
