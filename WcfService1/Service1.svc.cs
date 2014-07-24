using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private DataClasses1DataContext db = new DataClasses1DataContext();

        public StudentKlasa GetStudent(int id)
        {
            var query = (from s in db.StdntTabelas
                         where s.ID_Stdnt == id
                         select new { s.ID_Stdnt, s.ImieStdnt, s.NazwiskoStdnt }).ToList();

            return new StudentKlasa(query[0].ID_Stdnt,query[0].ImieStdnt,query[0].NazwiskoStdnt);
            
        }


        public int SetStudent(string imie, string nazwisko)
        {
            StdntTabela S = new StdntTabela();
            S.ImieStdnt = imie;
            S.NazwiskoStdnt = nazwisko;
            db.StdntTabelas.InsertOnSubmit(S);
            db.SubmitChanges();
            var query = (from s in db.StdntTabelas
                         where s.ImieStdnt == imie && s.NazwiskoStdnt == nazwisko
                         select new { s.ID_Stdnt }).ToList();
            return query[0].ID_Stdnt;
        }


    }
}
