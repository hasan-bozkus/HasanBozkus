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
    public class iletisimadresleriManager : IiletisimadresleriService
    {
        IiletisimadresleriDal _ıiletisimadresleriDal;

        public iletisimadresleriManager(IiletisimadresleriDal ıiletisimadresleriDal)
        {
            _ıiletisimadresleriDal = ıiletisimadresleriDal;
        }

        public List<iletisimadresleri> GetList()
        {
            return _ıiletisimadresleriDal.GetListAll();
        }

        public void TAdd(iletisimadresleri t)
        {
            _ıiletisimadresleriDal.Insert(t);
        }

        public void TDelete(iletisimadresleri t)
        {
            _ıiletisimadresleriDal.Delete(t);
        }

        public iletisimadresleri TGetById(int id)
        {
            return _ıiletisimadresleriDal.GetByID(id);
        }

        public void TUpdate(iletisimadresleri t)
        {
            _ıiletisimadresleriDal.Update(t);
        }
    }
}
