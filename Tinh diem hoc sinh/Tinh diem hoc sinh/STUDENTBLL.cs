using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinh_diem_hoc_sinh
{
    internal class STUDENTBLL
    {
        STUDENDAL dalSV;
        public STUDENTBLL()
        {
            dalSV= new STUDENDAL();
        }
        public DataTable GetAllSTUDENT()
        {
            return dalSV.GetAllSTUDENT();
        }
        public bool INSERTSTUDENT(STUDENT sv)
        {
            return dalSV.InsertSTUDENT(sv);
        }
        public bool UPDATESTUDENT(STUDENT sv)
        {
            return dalSV.UPDATESTUDENT(sv);
        }
        public bool DeleteSTUDENT(STUDENT sv)
        {
            return dalSV.DeleteSTUDENT(sv);
        }
       
    }


}
