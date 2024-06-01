using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_hospital
{
    public class Section
    {
        private int _idSection;
        private int _idPatient;
        private string _sectionName;
        private int _sectionFreeSeats;

        public Section(string proprietati)
        {
            String[] token = proprietati.Split(",");

            _idSection = int.Parse(token[0]);
            _idPatient = int.Parse(token[1]);
            _sectionName = token[2];
            _sectionFreeSeats = int.Parse(token[3]);
        }

        public Section(int idSection,int idPatient ,string sectionName,int sectionFreeSeats)
        {
            _idSection = idSection;
            _idPatient = idPatient;
            _sectionName = sectionName;
            _sectionFreeSeats= sectionFreeSeats;
        }

        public int IdSection
        {
            get { return _idSection; }
            set { _idSection = value; }
        }

        public int IdPatient
        {
            get { return _idPatient; }
            set { _idPatient = value; }
        }

        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        public int SectionFreeSeats
        {
            get { return _sectionFreeSeats; }
            set { _sectionFreeSeats = value; }
        }

        public string SectionInfo()
        {
            string text = " ";
            text += "Id sectie spital " + _idSection + "\n";
            text += "Id pacient " + _idPatient + "\n";
            text += "Nume sectie spital" + _sectionName + "\n";
            text += "Locuri libere " + _sectionFreeSeats + "\n";
            return text;
        }

        public string ToSave()
        {
            return this._idSection + "," + this._idPatient + "," + this._sectionName + "," + this._sectionFreeSeats;
        }
    }
}
