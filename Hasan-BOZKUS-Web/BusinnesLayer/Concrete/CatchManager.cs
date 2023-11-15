using BusinnesLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class CatchManager : ICatchService
    {
        ICatchDal _catchDal;

        public CatchManager(ICatchDal catchDal)
        {
            _catchDal = catchDal;
        }

        public List<Catch> GetCatchWithCategory()
        {
            throw new NotImplementedException();
        }

        public List<Catch> GetCatchWithCategory(int id)
        {
            return _catchDal.GetListWithCategory().ToList();
        }

        public List<Catch> GetCathById(int Id)
        {
            return _catchDal.GetListAll(x => x.CatchId == Id);
        }

        public List<Catch> GetList(int id)
        {
            return _catchDal.GetListAll(x => x.CatchId == id).ToList();
        }

        public List<Catch> GetList()
        {
            return _catchDal.GetListAll().ToList();
        }

        public void TAdd(Catch t)
        {
            _catchDal.Insert(t);
        }

        public void TDelete(Catch t)
        {
            _catchDal.Delete(t);
        }

        public Catch TGetById(int id)
        {
            return _catchDal.GetByID(id);
        }

        public void TUpdate(Catch t)
        {
            _catchDal.Update(t);
        }
    }
}
