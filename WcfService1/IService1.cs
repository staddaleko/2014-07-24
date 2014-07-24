using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        StudentKlasa GetStudent(int id);

        [OperationContract]
        int SetStudent(string imie, string nazwisko);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    
    [DataContract] //to się definiuje jako pierwsze
    public class StudentKlasa
    {
        //bool boolValue = true;
        //string stringValue = "Hello ";

        
        
        int id_studenta; //mała litera
        string imie;
        string nazwisko;
        
        [DataMember]
        public int Id_studenta //publiczne, więc duza litera
        {
            get { return id_studenta; }
            set { id_studenta = value; }
        }

        [DataMember]
        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }

        [DataMember]
        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }

        public StudentKlasa()
        { }
        
        public StudentKlasa(int _id, string _imie, string _nazwisko)
        {
            this.id_studenta = _id;
            this.imie = _imie;
            this.nazwisko = _nazwisko;
        }
    }
}
