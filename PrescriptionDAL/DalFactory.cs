using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionDAL
{
    public class DalFactory
    {
        public static IDal instance;

        protected DalFactory() { instance = null; }
        public static IDal getDal()
        {
            if (null == instance)
                instance = new DalImplement();
            return instance;
        }
    }
}
