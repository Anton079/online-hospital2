using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_hospital
{
    public class Doctor
    {
        private int _idDoctor;
        private string _parola;
        private string _doctorFirstName;
        private string _doctorLastName;
        private int _numberPhone;

        public Doctor(string proprietati)
        {
            String[] token = proprietati.Split(',');

            _idDoctor = int.Parse(token[0]);
            _parola = token[1];
            _doctorFirstName = token[2];
            _doctorLastName = token[3];
            _numberPhone = int.Parse(token[4]);
        }

        public Doctor(int idDoctor,string parola ,string doctorFirstName,string doctorLastName ,int numarTelefon)
        {
            _idDoctor=idDoctor;
            _parola=parola;
            _doctorFirstName=doctorFirstName;
            _doctorLastName=doctorLastName;
            _numberPhone = numarTelefon;
        }

        public int IdDoctor
        {
            get { return _idDoctor; }
            set { _idDoctor = value; }
        }

        public string Parola
        {
            get { return _parola; }
            set { _parola = value; }
        }

        public string DoctorName
        {
            get { return _doctorFirstName; }
            set { _doctorFirstName = value; }
        }

        public string DoctorLastName
        {
            get { return _doctorLastName; }
            set { _doctorLastName = value; }
        }

        public int NumarTelefon
        {
            get { return _numberPhone; }
            set { _numberPhone = value; }
        }

        public string DoctorInfo()
        {
            string text = " ";
            text += "Id doctor " + _idDoctor + "\n";
            text += "Parola " + _parola + "\n";
            text += "Numele doctorului " + _doctorFirstName + "\n";
            text += "Prenumele doctorului " + _doctorLastName + "\n";
            text += "Numar de telefon " + _numberPhone + "\n";
            return text;
        }

        public string ToSave()
        {
            return this._idDoctor + "," + this._parola + "," + this._doctorFirstName + "," + this._doctorLastName + "," + this._numberPhone;
        }

    }
}
