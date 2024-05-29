using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_hospital
{
    public class HospitalInformation
    {
        private string _programPublic;
        private int _hospitalPhone;
        private string _hospitalEmail;

        public HospitalInformation(string proprietati)
        {
            String[] token = proprietati.Split(',');

            _programPublic = token[0];
            _hospitalPhone = int.Parse(token[1]);
            _hospitalEmail = token[2];
        }

        public HospitalInformation( string programPublic, int hospitalPhone,string hospitalEmail)
        {
            _programPublic = programPublic;
            _hospitalPhone = hospitalPhone;
            _hospitalEmail=hospitalEmail;
        }

        public string ProgramPublic
        {
            get { return _programPublic; }
            set { _programPublic = value; }
        }

        public int HospitalPhone
        {
            get { return _hospitalPhone; }
            set { _hospitalPhone = value; }
        }

        public string HospitalEmail
        {
            get { return _hospitalEmail; }
            set { _hospitalEmail = value; }
        }

        public string HospitalInfo()
        {
            string text = " ";
            text += "Program public : " + _programPublic + "\n";
            text += "Număr de telefon spital : " + _hospitalPhone + "\n";
            text += "Email spital :" + _hospitalEmail + "\n";
            return text;
        }

        public string ToSave()
        {
            return this._programPublic + "," + this._hospitalPhone + "," + this._hospitalEmail;
        }
    }
}
