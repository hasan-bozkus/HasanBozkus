﻿using BusinnesLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public List<Notification> GetList()
        {
            return _notificationDal.GetListAll();
        }

        public void TAdd(Notification t)
        {
            _notificationDal.Insert(t);
        }

        public void TDelete(Notification t)
        {
            _notificationDal.Delete(t);
        }

        public Notification TGetById(int id)
        {
            return _notificationDal.GetByID(id);
        }

        public void TUpdate(Notification t)
        {
            throw new NotImplementedException();
        }
    }
}
