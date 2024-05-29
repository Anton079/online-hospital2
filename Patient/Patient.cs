using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_hospital
{
    public class Patient
    {
        private int _idPatient;
        private string _firstName;
        private string _lastName;
        private string _parola;
        private string _healthProblem;
        private string _degreeProblem;
        private int _dateHospitalization;
        private int _idDoctorPatient;

        public Patient(string proprieetati)
        {
            String[] token = proprieetati.Split(",");

            _idPatient = int.Parse(token[0]);
            _firstName = token[1];
            _lastName = token[2];
            _parola = token[3];
            _healthProblem = token[4];
            _degreeProblem = token[5];
            _dateHospitalization = int.Parse(token[6]);
            _idDoctorPatient = int.Parse(token[7]);
        }

        public Patient(int idPatient, string firstName, string lastName,string parola ,string healthProblem, string degreeProblem, int dateHospitalization, int idDoctorPatient)
        {
            _idPatient = idPatient;
            _firstName = firstName;
            _lastName = lastName;
            _parola = parola;
            _healthProblem = healthProblem;
            _degreeProblem = degreeProblem;
            _dateHospitalization = dateHospitalization;
            _idDoctorPatient = idDoctorPatient;
        }

        public int IdPatient
        {
            get { return _idPatient; }
            set { _idPatient = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Parola
        {
            get { return _parola; }
            set { _parola = value; }
        }

        public string HealthProblem
        {
            get { return _healthProblem; }
            set { _healthProblem = value; }
        }

        public string DegreeProblem
        {
            get { return _degreeProblem; }
            set { _degreeProblem = value; }
        }

        public int DateHospitalization
        {
            get { return _dateHospitalization;}
            set { _dateHospitalization = value;}
        }

        public int DoctorForPatient
        {
            get { return _idDoctorPatient; }
            set { _idDoctorPatient = value; }
        }

        public string PatientInfo()
        {
            string text = " ";
            text += "Patient id " + _idPatient + "\n";
            text += "First Name " + _firstName + "\n";
            text += "Last Name " + _lastName + "\n";
            text += "Parola " + _parola + "\n";
            text += "Health problem " + _healthProblem + "\n";
            text += "Degree problem " + _degreeProblem + "\n";
            text += "Date of hospitalization " + _dateHospitalization + "\n";
            text += "Doctorul pacientului " + _idDoctorPatient + "\n";
            return text;
        }

        public string ToSave()
        {
            return this._idPatient + "," + this._firstName + "," + this._lastName + "," + this._parola+ "," + this._healthProblem + ","  + this._degreeProblem + "," + this._dateHospitalization + "," + this._idDoctorPatient;
        }
    }
}
