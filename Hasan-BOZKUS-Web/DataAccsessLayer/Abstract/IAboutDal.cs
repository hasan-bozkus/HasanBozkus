﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Abstract
{
    public interface IAboutDal:IGenericDal<About>
    {
        List<About> Aboutagöremedyahesabigetir(int id);
    }
}
