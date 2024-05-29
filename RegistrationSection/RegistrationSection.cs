using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_hospital
{
    public class RegistrationSection
    {
        private int _idRegistration;
        private int _idPatient;
        private int _idSection;

        public RegistrationSection(string proprietati)
        {
            String[] token = proprietati.Split(',');

            _idRegistration = int.Parse(token[0]);
            _idPatient = int.Parse(token[1]);
            _idSection = int.Parse(token[2]);
        }

        public RegistrationSection(int idRegistration, int idPatient, int idSection)
        {
            _idRegistration = idRegistration;
            _idPatient = idPatient;
            _idSection = idSection;
        }

        public int IdRegistration
        {
            get { return _idRegistration; }
            set { _idRegistration = value; }
        }

        public int IdPatient
        {
            get { return _idPatient; }
            set { _idPatient = value; }
        }

        public int IdSection
        {
            get { return _idSection; }
            set { _idSection = value; }
        }

        public string RegistrationInfo()
        {
            string text = " ";
            text += "Id înregistrare: " + _idRegistration + "\n";
            text += "Id pacient: " + _idPatient + "\n";
            text += "Id secțiune: " + _idSection + "\n";
            return text;
        }

        public string ToSave()
        {
            return this._idRegistration + "," + this._idPatient + "," + this._idSection;
        }
    }
}
