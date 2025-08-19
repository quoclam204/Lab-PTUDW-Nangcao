using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityController
{
    public abstract class Base
    {
        public EF db;                  // Nếu bạn đặt context là TDAEntities thì đổi type & new tương ứng
        protected Base()
        {
            db = new EF();
        }
    }
}
