using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_hospital
{
    public class HospitalInformationService
    {
        private List<HospitalInformation> _hospitalInfo;

        public HospitalInformationService()
        {
            _hospitalInfo = new List<HospitalInformation>();
            this.LoadData();
        }

        public void LoadData()
        {
            try
            {
                using (StreamReader sr = new StreamReader(this.GetFilePath()))
                {
                    string line = " ";
                    while ((line = sr.ReadLine()) != null)
                    {
                        HospitalInformation hospitalInformation = new HospitalInformation(line);
                        this._hospitalInfo.Add(hospitalInformation);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string GetFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string folder = Path.Combine(currentDirectory, "data");

            string file = Path.Combine(folder, "hospitalInformation");

            return file;
        }

        public string ToSaveAll()
        {
            String save = "";

            for (int i = 0; i < _hospitalInfo.Count - 1; i++)
            {
                save += _hospitalInfo[i].ToSave() + "\n";
            }

            save += _hospitalInfo[_hospitalInfo.Count - 1].ToSave();

            return save;
        }

        public void SaveData()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(this.GetFilePath()))
                {
                    sw.Write(ToSaveAll());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //CRUD

        public void AfisareHospitalInformation()
        {
            foreach(HospitalInformation x in _hospitalInfo)
            {
                Console.WriteLine(x.HospitalInfo());
            }
        }

        public void AfisareProgram()
        {
            for(int i = 0; i < _hospitalInfo.Count ; i++)
            {
                Console.WriteLine(_hospitalInfo[i].ProgramPublic);
            }
        }

        public string EditInfoHospital(string newInfo)
        {
            for(int i =0; i < _hospitalInfo.Count; i++)
            {
                return newInfo = _hospitalInfo[i].ProgramPublic;

            }
            return null;
        }

    }
}
